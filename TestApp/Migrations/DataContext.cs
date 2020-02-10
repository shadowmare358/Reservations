using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestApp.Models;

namespace TestApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(): base()
        {
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
        }
        public DbSet<Guest> Guests { get; set; }

        public DbSet<Reservation> Reservations { get; set; }
    }
}