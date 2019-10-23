using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment5.Models
{
    public class GoogleResponse
    {
        public string status { get; set; }
        public GoogleResult[] results { get; set; }
    }
}