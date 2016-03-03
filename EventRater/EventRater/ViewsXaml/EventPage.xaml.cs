using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventRater.Controller;
using EventRater.Model;
using EventRater.Resources;
using Plugin.DeviceInfo;
using Xamarin.Forms;

namespace EventRater
{
    public partial class EventPage : ContentPage
    {
        public EventPage()
        {
            InitializeComponent();
            Activity.Opacity = 0;
            //this.RootGrid.BindingContext = EventRaterFacade.ConferenceRoot; // NOT WORKING YET, WITH XAML, XF2.0!?

            foreach (var evnt in EventRaterFacade.ConferenceRoot.Events)
            {
                this.RootGrid.Children.Add(new Label {Text = evnt.EventDetail.Name});
                this.RootGrid.Children.Add(new Label { Text = evnt.EventDetail.StartDate.ToString("U")});
                
                foreach (var lecturer in evnt.Lecturers)
                {
                    this.RootGrid.Children.Add(new Label { Text = lecturer.LecturerDetail.LastName + " " + lecturer.LecturerDetail.FirstName });
                    this.RootGrid.Children.Add(new Button
                    {
                        Text = AppResources.Vote,
                        Command = new Command( async () =>
                        {
                            Activity.Opacity = 100;
                            await EventRaterFacade.GetRatingsAsync(lecturer.LecturerDetail.Id, CrossDeviceInfo.Current.Id);
                            await this.Navigation.PushAsync(new LecturerPage());
                            Activity.Opacity = 0;
                        })
                    });
                }
            }
        }

    }
}
