using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventRater.Controller;
using EventRater.Model;
using Plugin.DeviceInfo;
using Xamarin.Forms;

namespace EventRater
{
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
            // UWP Activity.IsRunning bug
            Activity.Opacity = 0;
        }

        private async void GetEvents_OnClicked(object sender, EventArgs e)
        {
            Activity.Opacity = 100;
            // conf || EventRaterFacace.ConferenceRoot ??
            ConferenceRootObject conf = await EventRaterFacade.GetEventsAsync(EventCodeEntry.Text, CrossDeviceInfo.Current.Id);
            if(conf.Error == null && conf.Conference != null && conf.Events != null)
                await this.Navigation.PushAsync(new EventPage());
            else
                this.DisplayAlert("Result", conf.Error==null?"null":conf.Error.ToString(), "OK");
            Activity.Opacity = 0;
        }
    }
}
