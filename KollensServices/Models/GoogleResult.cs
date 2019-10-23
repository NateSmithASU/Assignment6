using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment5.Models
{
    public class GoogleResult
    {
        public AddressComponents[] address_components { get; set; }

        public string formatted_address { get; set; }

        public GeometryModel geometry { get; set; }

        public string place_id { get; set; }

        public string[] types { get; set; }
    }
}