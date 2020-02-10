using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TestApp.Data;
using TestApp.Models;

namespace TestApp.Controllers
{
    public class GuestsController : ApiController
    {
        private DataContext db = new DataContext();

        public IQueryable<Guest> GetGuests()
        {
            return db.Guests;
        }

        [ResponseType(typeof(Guest))]
        public IHttpActionResult GetGuest(int id)
        {
            Guest guest = db.Guests.Find(id);
            if (guest == null)
            {
                return NotFound();
            }

            return Ok(guest);
        }

        [Route("api/Guests/{name}")]
        [ResponseType(typeof(Guest))]
        public IHttpActionResult DeleteGuestNames(string name)
        {
            if (name == "piotr"){
                var guestPeter = db.Guests.Where(guest => guest.Name == name);
                db.Guests.RemoveRange(guestPeter);
                db.SaveChanges();
            }
            else{
                return BadRequest();
            }
            db.SaveChanges();
            return Ok();
        }

        [Route("api/Guests/{name}/{city}")]
        [ResponseType(typeof(Guest))]
        public IHttpActionResult DeleteGuestCities(string name, string city)
        {
            if (name == "piotr" && city == "wroclaw"){
                var guestPeter = db.Guests.Where(guest => guest.Name == name && guest.City == city);
                db.Guests.RemoveRange(guestPeter);
                db.SaveChanges();
            }
            else{
                return BadRequest();
            }
            db.SaveChanges();
            return Ok();
        }


protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GuestExists(int id)
        {
            return db.Guests.Count(e => e.Id == id) > 0;
        }
    }
}