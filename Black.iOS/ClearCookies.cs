using System;
using System.Net;
using Foundation;
using Xamarin.Forms;

[assembly: Dependency(typeof(Black.iOS.ClearCookies))]
namespace Black.iOS
{
    public class ClearCookies : IClearCookies
    {
        public void Clear()
        {
            NSHttpCookieStorage CookieStorage = NSHttpCookieStorage.SharedStorage;
            foreach (var cookie in CookieStorage.Cookies)
                CookieStorage.DeleteCookie(cookie);
        }
    }
}