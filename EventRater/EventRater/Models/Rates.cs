using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventRater.Model
{
    public class RatesRootObject
    {
        public List<string> Rates { get; set; }
        public string DeviceUUID { get; set; }
        public string EventLecturerId { get; set; }
    }
}

/*
{
    "Rates": [
        "5",
        "4",
        "3",
        "2",
        "1"
    ],
    "DeviceUUID": "a50630ce0e4f42c0",
    "EventLecturerId": "22"
}
*/
