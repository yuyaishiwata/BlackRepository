using Xamarin.Forms;
using System.Net;
using Android.Webkit;

[assembly: Dependency(typeof(Black.Droid.ClearCookies))]
namespace Black.Droid
{
    public class ClearCookies : IClearCookies
    {
        public void Clear()
        {
            var cookieManager = CookieManager.Instance;
            cookieManager.RemoveAllCookie();
        }
    }
}