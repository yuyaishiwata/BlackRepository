using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

using Newtonsoft.Json;

namespace Black.Models
{
    public class AuthorizationCodeAuth
    {
        static readonly string AuthorizationCodeRequestUrl = "https://accounts.spotify.com/authorize";
        static readonly string TokenRequestUrl = "https://accounts.spotify.com/api/token";
        static readonly string RedirectUrl = "black://localhost/auth/spotify";
        static readonly string ClientId = "ac39a6ec468241e0b5580a1193f5084c";
        static readonly string ClientSecret = "8c045a005693450c87e7fedac1dbbaff";

        public string AccessToken { get; private set; } = string.Empty;
        public string RefreshToken { get; private set; } = string.Empty;
        public int ExpiresIn { get; private set; } = 0;
        public string Scope { get; private set; } = string.Empty;
        public string TokenType { get; private set; } = string.Empty;

        public DateTime StartTime { get; set; }

        private AuthorizationCodeAuth() { }

        public static string GetUrl(string scope = "user-read-private")
        {
            NameValueCollection query = HttpUtility.ParseQueryString(string.Empty);
            query.Add("client_id", ClientId);
            query.Add("response_type", "code");
            query.Add("scope", scope);
            query.Add("redirect_uri", RedirectUrl);

            return AuthorizationCodeRequestUrl + "?" + query;
        }

        public static async Task<AuthorizationCodeAuth> GetToken(string authorizationCode)
        {
            HttpResponseMessage response = await SendAccessRequestAsync(authorizationCode);

            string json = await response.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeAnonymousType(json, new
            {
                access_token = string.Empty,
                token_type = string.Empty,
                scope = string.Empty,
                expires_in = 0,
                refresh_token = string.Empty
            });

            if (string.IsNullOrEmpty(jsonObject.access_token) || string.IsNullOrEmpty(jsonObject.refresh_token))
                return null;

            return new AuthorizationCodeAuth {
                AccessToken = jsonObject.access_token,
                RefreshToken = jsonObject.refresh_token,
                Scope = jsonObject.scope,
                ExpiresIn = jsonObject.expires_in,
                TokenType = jsonObject.token_type,
                StartTime = DateTime.Now
            };
        }

        public static async Task<AuthorizationCodeAuth> GetTokenByRefreshToken(string refreshToken)
        {
            var auth = new AuthorizationCodeAuth { RefreshToken = refreshToken };
            return await auth.Refresh();
        }

        static async Task<HttpResponseMessage> SendAccessRequestAsync(string authorizationCode)
        {
            string auth = Convert.ToBase64String(Encoding.UTF8.GetBytes(ClientId + ":" + ClientSecret));
            var bodyParameters = new Dictionary<string, string>
            {
                { "grant_type", "authorization_code" },
                { "code",  authorizationCode},
                { "redirect_uri", RedirectUrl }
            };

            var request = new HttpRequestMessage(HttpMethod.Post, TokenRequestUrl);
            request.Headers.Add("Authorization", "Basic " + auth);
            request.Content = new FormUrlEncodedContent(bodyParameters);

            return await new HttpClient().SendAsync(request);
        }

        public bool IsRun(int threshold = 100)
        {
            TimeSpan ts = DateTime.Now - StartTime;
            return ts.TotalSeconds < ExpiresIn - threshold;
        }

        public async Task<AuthorizationCodeAuth> Refresh()
        {
            HttpResponseMessage response = await SendRefreshRequestAsync();

            string json = await response.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeAnonymousType(json, new
            {
                access_token = string.Empty,
                token_type = string.Empty,
                scope = string.Empty,
                expires_in = 0
            });

            if (string.IsNullOrEmpty(jsonObject.access_token))
                return null;

            AccessToken = jsonObject.access_token;
            Scope = jsonObject.scope;
            ExpiresIn = jsonObject.expires_in;
            TokenType = jsonObject.token_type;
            StartTime = DateTime.Now;

            return this;
        }

        async Task<HttpResponseMessage> SendRefreshRequestAsync()
        {
            string auth = Convert.ToBase64String(Encoding.UTF8.GetBytes(ClientId + ":" + ClientSecret));
            var bodyParameters = new Dictionary<string, string>
            {
                { "grant_type", "refresh_token" },
                { "refresh_token",  RefreshToken},
            };

            var request = new HttpRequestMessage(HttpMethod.Post, TokenRequestUrl);
            request.Headers.Add("Authorization", "Basic " + auth);
            request.Content = new FormUrlEncodedContent(bodyParameters);

            return await new HttpClient().SendAsync(request);
        }
    }
}
