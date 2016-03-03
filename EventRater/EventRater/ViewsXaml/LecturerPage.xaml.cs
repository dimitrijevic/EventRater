using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventRater.Controller;
using EventRater.Model;
using Plugin.DeviceInfo;
using Xamarin.Forms;

namespace EventRater
{
    public partial class LecturerPage : ContentPage
    {
        public LecturerPage()
        {
            InitializeComponent();
            Activity.Opacity = 0;
            this.LecturerName.Text = EventRaterFacade.LecturerRoot.LecturerDetail.FirstName + " " +
                                     EventRaterFacade.LecturerRoot.LecturerDetail.LastName;
            this.PickerClarity.SelectedIndex = EventRaterFacade.LecturerRoot.Rating[0];
            this.PickerSuitability.SelectedIndex = EventRaterFacade.LecturerRoot.Rating[1];
            this.PickerLectureMethod.SelectedIndex = EventRaterFacade.LecturerRoot.Rating[2];
            this.PickerSpeakerKnowledge.SelectedIndex = EventRaterFacade.LecturerRoot.Rating[3];
            this.PickerSpeakerStyle.SelectedIndex = EventRaterFacade.LecturerRoot.Rating[4];
        }

        private async void AddRates_OnClicked(object sender, EventArgs e)
        {
            Activity.Opacity = 100;
            List<string> rates = new List<string>() {
                this.PickerClarity.SelectedIndex.ToString(),
                this.PickerSuitability.SelectedIndex.ToString(),
                this.PickerLectureMethod.SelectedIndex.ToString(),
                this.PickerSpeakerKnowledge.SelectedIndex.ToString(),
                this.PickerSpeakerStyle.SelectedIndex.ToString()
            };

            RatesRootObject rate = new RatesRootObject();
            rate.DeviceUUID = CrossDeviceInfo.Current.Id;
            rate.EventLecturerId = EventRaterFacade.LecturerRoot.EventLecturerId.ToString();
            rate.Rates = rates;

            await this.DisplayAlert("Result", await EventRaterFacade.AddRatesAsync(rate), "OK");
            Activity.Opacity = 0;
        }
    }
}
