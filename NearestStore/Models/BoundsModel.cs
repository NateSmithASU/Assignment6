using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NearestStore.Models
{
    public class BoundsModel
    {
        public BoundsLocationModel northeast { get; set; }
        public BoundsLocationModel southwest { get; set; }
    }
}