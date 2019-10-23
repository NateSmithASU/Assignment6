using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment5.Models
{
    public class WeatherResponse
    {
        public string error { get; set; }
        public string error_message { get; set; }
        public Forecast[] forecast { get; set; }
    }
}