using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Page), typeof(Black.iOS.CustomPageRenderer))]
namespace Black.iOS
{
    public class CustomPageRenderer : PageRenderer
    {
        public override bool PrefersStatusBarHidden()
        {
            return true;
        }
    }
}