﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NearestStore.Models
{
    public class NearestStoreResponse
    {
        public Candidates[] candidates { get; set; }

        public string status { get; set; }
    }
}