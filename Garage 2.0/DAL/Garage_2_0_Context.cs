using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Garage_2._0.DAL
{
    public class Garage_2_0_Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Garage_2_0_Context() : base("name=Garage_2_0_Context")
        {
        }

        public System.Data.Entity.DbSet<Garage_2._0.Models.Vehicle> Vehicles { get; set; }
    }
}
