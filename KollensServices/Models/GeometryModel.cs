using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment5.Models
{
    public class GeometryModel
    {
        public BoundsModel bounds { get; set; }

        public LocationModel location { get; set; }

        public string location_type { get; set; }

        public ViewPortModel viewport { get; set; }
    }
}