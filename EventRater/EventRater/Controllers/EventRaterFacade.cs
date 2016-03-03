using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventRater.Model;
using ModernHttpClient;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace EventRater.Controller
{
    public class EventRaterFacade
    {
        public static string result;
        public static LecturerRootObject LecturerRoot;
        public static ConferenceRootObject ConferenceRoot;

        /// <summary>
        /// Get events method
        /// </summary>
        /// <param name="code"></param>
        /// <param name="uuid"></param>
        /// <returns></returns>
        public static async Task<ConferenceRootObject> GetEventsAsync(string code, string uuid)
        {
            var client = new HttpClient(new NativeMessageHandler())
            {
                BaseAddress = new Uri("http://eventrater.vegaitsourcing.rs/events/")
            };
            var response = await client.GetAsync(String.Format("GetEvents?confcode={0}&deviceuuid={1}", code, uuid));
            var confJson = response.Content.ReadAsStringAsync().Result;
            ConferenceRoot = new ConferenceRootObject();
            if (confJson != "")
            {
                ConferenceRoot = JsonConvert.DeserializeObject<ConferenceRootObject>(confJson);
            }
            return ConferenceRoot;

        }

        /// <summary>
        /// Get ratings method
        /// </summary>
        /// <param name="lecturerId"></param>
        /// <param name="uuid"></param>
        /// <returns></returns>
        public static async Task<LecturerRootObject> GetRatingsAsync(int lecturerId, string uuid)
        {
            var client = new HttpClient(new NativeMessageHandler())
            {
                BaseAddress = new Uri("http://eventrater.vegaitsourcing.rs/events/")
            };
            var response = await client.GetAsync(String.Format("GetRatings?eventLecturerId={0}&deviceuuid={1}", lecturerId.ToString(), uuid));
            var confJson = response.Content.ReadAsStringAsync().Result;
            LecturerRoot = new LecturerRootObject();
            if (confJson != "")
            {
                LecturerRoot = JsonConvert.DeserializeObject<LecturerRootObject>(confJson);
            }
            return LecturerRoot;

        }

        /// <summary>
        /// Add rates method
        /// </summary>
        /// <param name="rates"></param>
        /// <returns></returns>
        public static async Task<string> AddRatesAsync(RatesRootObject rates)
        {
            var postdata = new System.Net.Http.StringContent(JsonConvert.SerializeObject(rates), System.Text.Encoding.UTF8, "application/json");
            var client = new HttpClient(new NativeMessageHandler())
            {
                BaseAddress = new Uri("http://eventrater.vegaitsourcing.rs/events/")
            };
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");

            var response = await client.PostAsync("AddRates", postdata);
            return result = response.Content.ReadAsStringAsync().Result;
        }

    }
}
