using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using EventRater.Resources;
using EventRater.ViewsXaml;
using Xamarin.Forms;

namespace EventRater
{
    public class App : Application
    {
        public App()
        {
            L10n.SetLocale();
            var netLanguage = DependencyService.Get<ILocale>().GetCurrent();
            AppResources.Culture = new CultureInfo(netLanguage);

            // The root page of your application
            MainPage = new NavigationPage(new StartPage()); ;
            //    new ContentPage
            //{
            //    Content = new StackLayout
            //    {
            //        VerticalOptions = LayoutOptions.Center,
            //        Children = {
            //            new Label {
            //                XAlign = TextAlignment.Center,
            //                Text = "Welcome to Xamarin Forms!"
            //            }
            //        }
            //    }
            //};
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
