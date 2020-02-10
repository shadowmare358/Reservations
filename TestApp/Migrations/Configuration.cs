namespace TestApp.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TestApp.Data.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TestApp.Data.DataContext context)
        {
            var guestList = new Collection<Guest>
    {
        new Guest { Name = "Krzystof", LastName = "Jelonka", Email = "kjelonka@wp.pl" , BirthDate = new DateTime(1956, 9, 12), PostCode="04-534"},
        new Guest { Name = "Filip", LastName = "Graszewski", Email = "jgraszewski@wp.pl" , BirthDate = new DateTime(2000, 9, 12), PostCode="04-629"}
    };

            context.Reservations.Add(new Reservation
            {
                CheckInDate = new DateTime(2020, 2, 5),
                CheckOutDate = new DateTime(2020, 5, 6),
                Currency = "PLN",
                Price = 340,
                Date = new DateTime(2020, 2, 3),
                ReservationCode = "1234567890",
                Fee = 100,
                Source = "Facebook"
            });
            context.Reservations.Add(new Reservation
            {
                CheckInDate = new DateTime(2020, 6, 1),
                CheckOutDate = new DateTime(2020, 6, 10),
                Currency = "EUR",
                Price = 500,
                Date = new DateTime(2020, 2, 4),
                ReservationCode = "0987654321",
                Fee = 150,
                Source = "Web",
                Guests = guestList
            });

            context.Guests.Add(new Guest
            {
                Name = "Marek",
                LastName = "Mądry",
                Email = "mmadry@wp.pl",
                BirthDate = new DateTime(1993, 1, 1),
                PostCode = "08-123"
            });
            context.Guests.Add(new Guest
            {
                Name = "Adam",
                LastName = "Kowalski",
                Email = "akowalski@wp.pl",
                BirthDate = new DateTime(1973, 12, 5),
                PostCode = "11-984"
            });
            context.Guests.Add(new Guest
            {
                Name = "Roman",
                LastName = "Romanowski",
                Email = "rromanowski@wp.pl",
                BirthDate = new DateTime(1985, 4, 10),
                PostCode = "01-234"
            });
            context.Guests.Add(new Guest
            {
                Name = "Ryszard",
                LastName = "Marcinowski",
                Email = "rmarcinowski@wp.pl",
                BirthDate = new DateTime(1956, 9, 12),
                PostCode = "05-256"
            });
            context.Guests.Add(new Guest
            {
                Name = "Piotr",
                LastName = "Marcinowski",
                Email = "pmarcinowski@wp.pl",
                BirthDate = new DateTime(1956, 9, 12),
                PostCode = "05-256"
            });
            context.Guests.Add(new Guest
            {
                Name = "Piotr",
                LastName = "Abacki",
                Email = "pabacki@wp.pl",
                BirthDate = new DateTime(1956, 9, 12),
                PostCode = "05-256"
            });

        }
    }
}
