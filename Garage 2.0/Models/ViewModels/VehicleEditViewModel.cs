using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Garage_2._0.Models.ViewModels
{
    public class VehicleEditViewModel
    {
        public Vehicle Vehicle { get; set; }
        public SelectList VehicleTypeList { get; set; }
    }
}