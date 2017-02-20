using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage_2._0.Models
{
    public class Member
    {
        public int MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return (FirstName + " " + LastName); } }
        public string PhoneNumber { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
        public virtual ICollection<VehicleType> VehicleTypes { get; set; }
    }
}