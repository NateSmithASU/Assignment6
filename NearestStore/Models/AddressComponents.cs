using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NearestStore.Models
{
    public class AddressComponents
    {
        public string long_name { get; set; }
        public string short_name { get; set; }
        public string[] types { get; set; }
    }
}