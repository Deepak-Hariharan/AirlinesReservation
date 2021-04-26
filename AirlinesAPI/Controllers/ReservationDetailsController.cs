﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AirlinesAPI;

namespace AirlinesAPI.Controllers
{
    public class ReservationDetailsController : ApiController
    {
        private AssignmentDBEntities db = new AssignmentDBEntities();

        // GET: api/ReservationDetails
        public IQueryable<ReservationDetail> GetReservationDetails()
        {
            return db.ReservationDetails;
        }

        // GET: api/ReservationDetails/5
        [ResponseType(typeof(ReservationDetail))]
        public IHttpActionResult GetReservationDetail(string id)
        {
            ReservationDetail reservationDetail = db.ReservationDetails.Find(id);
            if (reservationDetail == null)
            {
                return NotFound();
            }

            return Ok(reservationDetail);
        }

        // PUT: api/ReservationDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutReservationDetail(string id, ReservationDetail reservationDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reservationDetail.PNRNo)
            {
                return BadRequest();
            }

            db.Entry(reservationDetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ReservationDetails
        [ResponseType(typeof(ReservationDetail))]
        public IHttpActionResult PostReservationDetail(ReservationDetail reservationDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ReservationDetails.Add(reservationDetail);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ReservationDetailExists(reservationDetail.PNRNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = reservationDetail.PNRNo }, reservationDetail);
        }

        // DELETE: api/ReservationDetails/5
        [ResponseType(typeof(ReservationDetail))]
        public IHttpActionResult DeleteReservationDetail(string id)
        {
            ReservationDetail reservationDetail = db.ReservationDetails.Find(id);
            if (reservationDetail == null)
            {
                return NotFound();
            }

            db.ReservationDetails.Remove(reservationDetail);
            db.SaveChanges();

            return Ok(reservationDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReservationDetailExists(string id)
        {
            return db.ReservationDetails.Count(e => e.PNRNo == id) > 0;
        }
    }
}