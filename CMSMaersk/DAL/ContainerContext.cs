using CMSMaersk.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CMSMaersk.DAL
{
    public class ContainerContext : DbContext
    {
        public ContainerContext()
        {
            Database.SetInitializer(new ContainerInitializer());
            Database.Initialize(true);
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Vessel> Vessels { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Item> Items { get; set; }
    }
}