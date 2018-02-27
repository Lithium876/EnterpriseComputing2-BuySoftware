﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1401375.Models
{
    public class Software
    {
        public String SoftwareId { get; set; }
        public String SoftwareName { get; set; }
        public int SoftwareAmount { get; set; }
        public String SoftwareCost { get; set; }
        public Double SoftwareTotalCost { get; set; }

        public Double calculateSoftwareTotalCost()
        {
            SoftwareCost = SoftwareCost.Replace(", ", "");
            return Convert.ToDouble(SoftwareCost) * SoftwareAmount;
        }

        public Software()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}