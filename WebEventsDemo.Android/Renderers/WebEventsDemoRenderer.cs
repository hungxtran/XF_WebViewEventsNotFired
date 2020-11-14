using System;
using WebEventsDemo.Renderers;
using WebEventsDemo.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Content;

[assembly: ExportRenderer(typeof(WebViewDemo), typeof(WebEventsDemoRenderer))]
namespace WebEventsDemo.Droid.Renderers
{
    public class WebEventsDemoRenderer : WebViewRenderer
    {
        public WebEventsDemoRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                // Open this line to activate the workaround
                //Control.Settings.SetSupportMultipleWindows(false);
            }
        }
    }
}
