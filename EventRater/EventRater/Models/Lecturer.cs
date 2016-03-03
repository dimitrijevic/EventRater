using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EventRater.Model
{

    //public class LecturerDetail
    //{
    //    public int Id { get; set; }
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //}

    public class LecturerRootObject
    {
        [JsonProperty("Lecturer")]
        public LecturerDetail LecturerDetail { get; set; }
        public List<int> Rating { get; set; }
        public int EventLecturerId { get; set; }
    }
}

/*
{
    "Lecturer": {
        "Id": 22,
        "FirstName": "Ljubomir",
        "LastName": "Simin"
    },
    "Rating": [
        5,
        4,
        3,
        2,
        1
    ],
    "EventLecturerId": 22
}
*/
