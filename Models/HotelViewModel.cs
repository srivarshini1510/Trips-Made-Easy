using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelReservationSystem.Models
{
    public class HotelViewModel
    {
        public string hotelnm { get; set; }
        public string description { get; set; }
        public string amenities { get; set; }
        public string roomdetails { get; set; }
        public string imagenm { get; set; }
        public string address { get; set; }
    }
}