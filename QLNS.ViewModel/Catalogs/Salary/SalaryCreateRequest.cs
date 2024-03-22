﻿using QLNS.Entity.Entities;
using QLNS.Entity.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS.ViewModel.Catalogs.Salary
{
    public class SalaryCreateRequest
    {
        public string ID { get; set; }
        public string RankID { get; set; }
        public string PositionID { get; set; }

        [RegularExpression("^[0-9]+$")]
        public decimal Money { get; set; }
    }
}