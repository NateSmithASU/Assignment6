using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NearestStore.Models
{
    public class ViewPortModel
    {
        public BoundsLocationModel northeast { get; set; }
        public BoundsLocationModel southwest { get; set; }
    }
}