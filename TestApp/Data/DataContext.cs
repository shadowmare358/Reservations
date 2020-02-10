using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Test.Models;

namespace Test.Data
{
    public class DataContext : DbContext
    {
        public DataContext(): base()
        {

        }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}