﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS.ViewModel.Catalogs.LabourDays
{
    public class LabourDayCreateRequest
    {
        public string IDLB { get; set; }
        public string Name { get; set; }
        public int Days { get; set; }
        public int Months { get; set; }
    }
}