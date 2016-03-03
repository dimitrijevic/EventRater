using System;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace EventRater.ViewsXaml
{
    public interface ILocale
    {
        string GetCurrent();

        void SetLocale(string Locale = null);
    }

    // You exclude the 'Extension' suffix when using in Xaml markup
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                return null;
            Debug.WriteLine("Provide: " + Text);
            // Do your translation lookup here, using whatever method you require
            var translated = L10n.Localize(Text, Text);

            return translated;
        }
    }

    public class L10n
    {
        public static void SetLocale(string argLocale = null)
        {
            DependencyService.Get<ILocale>().SetLocale(argLocale);
        }

        /// <remarks>
        /// Maybe we can cache this info rather than querying every time
        /// </remarks>
        public static string Locale()
        {
            return DependencyService.Get<ILocale>().GetCurrent();
        }

        public static string Localize(string key, string tre)
        {

            var netLanguage = Locale();
            // Platform-specific
            ResourceManager temp = new ResourceManager("EventRater.Resources.AppResources", typeof(L10n).GetTypeInfo().Assembly);
            Debug.WriteLine("Localize " + key);
            string result = temp.GetString(key, new CultureInfo(netLanguage));

            return result;
        }
    }
}
