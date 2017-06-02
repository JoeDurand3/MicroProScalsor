using MicroProScalsor.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MicroProScalsor
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            SetMainPage();
        }

        /// <summary>
        /// Sets the main page.
        /// </summary>
        public static void SetMainPage()
        {
            Current.MainPage = new TabbedPage
            {
                Children =
                {
                    new NavigationPage(new ScalePage())
                    {
                        Title = "Scale",
                        Icon = StringOnPlatform("tab_feed.png")
                    },
                    new NavigationPage(new SettingsPage())
                    {
                        Title = "Settings",
                        Icon = StringOnPlatform("tab_feed.png")
                    },
                    new NavigationPage(new AboutPage())
                    {
                        Title = "About",
                        Icon = StringOnPlatform("tab_feed.png")
                    },
                }
            };
        }

        /// <summary>
        /// Switches string value based on platform.
        /// </summary>
        /// <param name="iOS">The i os.</param>
        /// <param name="Android">The android.</param>
        /// <param name="Windows">The windows.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException">Platform behavior unspecified.</exception>
        private static string StringOnPlatform(string iOS = null, string Android = null, string Windows = null)
        {
            switch(Device.RuntimePlatform)
            {
                case Device.iOS:
                    return iOS;
                case Device.Android:
                    return Android;
                case Device.Windows:
                    return Windows;
            }

            throw new NotImplementedException("Platform behavior unspecified.");
        }
    }
}
