using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment5.Models
{
    public class Forecast
    {
        public string date { get; set; }
        public string avg_c { get; set; }
        public string min_c { get; set; }
        public string max_c { get; set; }
        public string avg_f { get; set; }
        public string min_f { get; set; }
        public string max_f { get; set; }
        public string summary { get; set; }
        public string icon { get; set; }
    }
}