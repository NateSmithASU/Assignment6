using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NearestStore.Models
{
    public class GoogleResponse
    {
        public string status { get; set; }
        public GoogleResult[] results { get; set; }
    }
}