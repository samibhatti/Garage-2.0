using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Garage_2._0.Models;

namespace Garage_2._0.DAL
{
    public class Garage_2_5_Context : DbContext
    {
        public Garage_2_5_Context() : base("Garage2_5_Context")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new GarageContextInitializer());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Vehicle> Vehicles {get;set;}
        public DbSet<VehicleType> VehicleTypes { get; set; }

    }
}