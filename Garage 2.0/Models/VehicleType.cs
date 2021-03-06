﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage_2._0.Models
{
    public class VehicleType
    {
        public int Id { get; set; }
        [Display(Name = "Vehicle Type")]
        public string Name { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
        public virtual ICollection<Member> Members { get; set; }
    }
}