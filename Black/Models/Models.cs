using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Newtonsoft.Json;

using Black.Exception;

namespace Black.Models
{

    public static class Models
    {
        public readonly static string RootEndPoint = "https://api.spotify.com/v1";
        public static AuthorizationCodeAuth Auth { get; private set; }

        public static bool IsValided() => Auth != null;
        public static void Initialize(AuthorizationCodeAuth auth) => Auth = auth;
        public static async Task<string> GetAccessToken() => Auth.IsRun() ? Auth.AccessToken : (await Auth.Refresh()).AccessToken;
    }

    public abstract class Models<TModel> : List<TModel>
    {
        protected static async Task<TDeserialized> GetAsync<TDeserialized>(string path)
        {
            if (!Models.IsValided())
                throw new InvalidAuthorizationException("Authフィールドに認証用インスタンスが登録されていません。");

            using (var request = new HttpRequestMessage(HttpMethod.Get, Models.RootEndPoint + path))
            using (var client = new HttpClient())
            {
                request.Headers.Add("Authorization", "Bearer " + await Models.GetAccessToken());

                HttpResponseMessage response = await client.SendAsync(request);
                string json = await response.Content.ReadAsStringAsync();
                response.Dispose();

                return JsonConvert.DeserializeObject<TDeserialized>(json);
            }
        }

        /*
        protected static async Task<string> Post(string url)
        {
        }

        protected static async Task<string> Put(string url)
        {
        }

        protected static async Task<string> Delite(string url)
        {
        }
        */

        public bool LoadPaging(Paging<TModel> paging) => LoadPaging(paging, null);

        public bool LoadPaging<TPagingType>(Paging<TPagingType> paging, Func<TPagingType, TModel> selectFunc)
        {
            if (paging == null)
                return false;

            var items = selectFunc == null ?
                paging.Items as IEnumerable<TModel> :
                paging.Items.Select(selectFunc) as IEnumerable<TModel>;

            if (items == null)
                return false;

            Clear();
            foreach (var item in items)
            {
                Add(item);
            }

            return true;
        }

    }
}
