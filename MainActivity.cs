using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using AndroidX.AppCompat.App;

namespace OptionsMenusDemo_Xamarin_Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        WebView web_view;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            // and attach an event to it
            web_view = FindViewById<WebView>(Resource.Id.webView1);
            web_view.SetWebViewClient(new HelloWebViewClient());
            web_view.Settings.JavaScriptEnabled = true;
            web_view.LoadUrl("http://www.google.com");
        }

        public class HelloWebViewClient : WebViewClient
        {
            public override bool ShouldOverrideUrlLoading(WebView view, string url)
            {
                view.LoadUrl(url);
                return true;
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            menu.Add("Twitter");
            menu.Add("Facebook");
            menu.Add("Instagram");
            return base.OnPrepareOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            var itemTitle = item.TitleFormatted.ToString();

            switch (itemTitle)
            {
                case "Twitter":
                    web_view.LoadUrl("http://www.twitter.com");
                    break;
                case "Facebook":
                    web_view.LoadUrl("http://www.facebook.com");
                    break;
                case "Instagram":
                    web_view.LoadUrl("http://www.instagram.com");
                    break;
            }

            return base.OnOptionsItemSelected(item);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}