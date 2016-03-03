using System;
using Xamarin.Forms;
using System.Runtime.CompilerServices;
using System.Threading;

[assembly: Xamarin.Forms.Dependency(typeof(EventRater.WinPhone.Localize))]

namespace EventRater.WinPhone
{
    public class Localize : EventRater.ViewsXaml.ILocale
    {
        public string GetCurrent()
        {
            return GetCurrentCultureInfo().Name;
        }

        public void SetLocale(string Locale = null)
        {
            //
        }

        public System.Globalization.CultureInfo GetCurrentCultureInfo()
        {
            return System.Threading.Thread.CurrentThread.CurrentUICulture;
        }
    }
}
