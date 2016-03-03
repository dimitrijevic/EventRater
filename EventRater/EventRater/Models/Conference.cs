using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EventRater.Model
{
    public class ConferenceRootObject : INotifyPropertyChanged
    {
        public Conference Conference { get; set; }
        public List<Event> Events { get; set; }
        public object Error { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
    public class Conference
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime? VotingEndDate { get; set; }
    }

    public class Event
    {
        [JsonProperty("Event")]
        public EventDetail EventDetail { get; set; }
        public List<Lecturer> Lecturers { get; set; }
    }

    public class EventDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ConferenceId { get; set; }
    }

    public class Lecturer
    {
        [JsonProperty("Lecturer")]
        public LecturerDetail LecturerDetail { get; set; }
        public string Rating { get; set; }
        public int EventLecturerId { get; set; }
    }

    public class LecturerDetail
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

/*
 meetup
{"Conference":null,"Events":null,"Error":"event_ended"}

 meetup2
{"Conference":null,"Events":null,"Error":null} 

 test
{
    "Conference": {
        "Id": 3,
        "Name": "Test Conf",
        "Code": "test",
        "VotingEndDate": null
    },
    "Events": [
        {
            "Event": {
                "Id": 17,
                "Name": "Predavanje Laje",
                "StartDate": "/Date(1447578000000)/",
                "EndDate": "/Date(1447581600000)/",
                "ConferenceId": 3
            },
            "Lecturers": [
                {
                    "Lecturer": {
                        "Id": 18,
                        "FirstName": "Milos",
                        "LastName": "Lajic"
                    },
                    "Rating": null,
                    "EventLecturerId": 18
                }
            ]
        },
        {
            "Event": {
                "Id": 18,
                "Name": "Predavanje Maje i Maje",
                "StartDate": "/Date(1447578000000)/",
                "EndDate": "/Date(1447581600000)/",
                "ConferenceId": 3
            },
            "Lecturers": [
                {
                    "Lecturer": {
                        "Id": 19,
                        "FirstName": "Maja",
                        "LastName": "Neducic"
                    },
                    "Rating": null,
                    "EventLecturerId": 19
                },
                {
                    "Lecturer": {
                        "Id": 20,
                        "FirstName": "Maja",
                        "LastName": "Bozic"
                    },
                    "Rating": null,
                    "EventLecturerId": 20
                }
            ]
        },
        {
            "Event": {
                "Id": 19,
                "Name": "Predavanje Dejana",
                "StartDate": "/Date(1450170000000)/",
                "EndDate": "/Date(1450173600000)/",
                "ConferenceId": 3
            },
            "Lecturers": [
                {
                    "Lecturer": {
                        "Id": 21,
                        "FirstName": "Dejan",
                        "LastName": "Dragic"
                    },
                    "Rating": null,
                    "EventLecturerId": 21
                }
            ]
        }
    ],
    "Error": null
}
*/
