﻿using Newtonsoft.Json;
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
    public class ReservationsController : ApiController
    {
        private DataContext db = new DataContext();

        public IQueryable<Reservation> GetReservations()
        {
            return db.Reservations.Include(g => g.Guests);
        }

        [ResponseType(typeof(Reservation))]
        public IHttpActionResult GetReservation(int id)
        {
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return NotFound();
            }

            return Ok(reservation);
        }

        [ResponseType(typeof(Reservation))]
        public IHttpActionResult PostReservation(Reservation reservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Reservations.Add(reservation);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = reservation.Id }, reservation);
        }

        [ResponseType(typeof(Reservation))]
        public IHttpActionResult DeleteAllReservations()
        {

            db.Reservations.RemoveRange(db.Reservations);
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

        private bool ReservationExists(int id)
        {
            return db.Reservations.Count(e => e.Id == id) > 0;
        }
    }
}