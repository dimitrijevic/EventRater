using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;

[assembly: Dependency(typeof(EventRater.Droid.Localize))]

namespace EventRater.Droid
{
    public class Localize : EventRater.ViewsXaml.ILocale
    {
        public void SetLocale(string androidLocale = null)
        {
            if (androidLocale == null)
                androidLocale = Java.Util.Locale.Default.ToString().Replace("_", "-"); // user's preferred locale

            var spliter = new Char[] {'-'};

            if (androidLocale.Split(spliter)[0]=="sr")
                androidLocale = androidLocale.Split(spliter)[0] + "-Latn";
            
            var netLocale = androidLocale;
            var ci = new System.Globalization.CultureInfo(netLocale);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }

        /// <remarks>
        /// Not sure if we can cache this info rather than querying every time
        /// </remarks>
        public string GetCurrent()
        {
            var androidLocale = new Java.Util.Locale(Thread.CurrentThread.CurrentCulture.Name); // Java.Util.Locale.Default; // user's preferred locale
            
            // en, es, ja
            var netLanguage = androidLocale.Language.Replace("_", "-");
            // en-US, es-ES, ja-JP
            var netLocale = androidLocale.ToString().Replace("_", "-");

            #region Debugging output
            Console.WriteLine("android:  " + androidLocale.ToString());
            Console.WriteLine("netlang:  " + netLanguage);
            Console.WriteLine("netlocale:" + netLocale);

            var ci = new System.Globalization.CultureInfo(netLocale);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            Console.WriteLine("thread:  " + Thread.CurrentThread.CurrentCulture);
            Console.WriteLine("threadui:" + Thread.CurrentThread.CurrentUICulture);
            #endregion

            return netLocale;
        }
    }
}
