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
using AirlinesAPI;

namespace AirlinesAPI.Controllers
{
    public class ReservationMastersController : ApiController
    {
        private AssignmentDBEntities db = new AssignmentDBEntities();

        // GET: api/ReservationMasters
        public IQueryable<ReservationMaster> GetReservationMasters()
        {
            return db.ReservationMasters;
        }

        // GET: api/ReservationMasters/5
        [ResponseType(typeof(ReservationMaster))]
        public IHttpActionResult GetReservationMaster(string id)
        {
            ReservationMaster reservationMaster = db.ReservationMasters.Find(id);
            if (reservationMaster == null)
            {
                return NotFound();
            }

            return Ok(reservationMaster);
        }

        // PUT: api/ReservationMasters/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutReservationMaster(string id, ReservationMaster reservationMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reservationMaster.PNRNo)
            {
                return BadRequest();
            }

            db.Entry(reservationMaster).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationMasterExists(id))
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

        // POST: api/ReservationMasters
        [ResponseType(typeof(ReservationMaster))]
        public IHttpActionResult PostReservationMaster(ReservationMaster reservationMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ReservationMasters.Add(reservationMaster);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ReservationMasterExists(reservationMaster.PNRNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = reservationMaster.PNRNo }, reservationMaster);
        }

        // DELETE: api/ReservationMasters/5
        [ResponseType(typeof(ReservationMaster))]
        public IHttpActionResult DeleteReservationMaster(string id)
        {
            ReservationMaster reservationMaster = db.ReservationMasters.Find(id);
            if (reservationMaster == null)
            {
                return NotFound();
            }

            db.ReservationMasters.Remove(reservationMaster);
            db.SaveChanges();

            return Ok(reservationMaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReservationMasterExists(string id)
        {
            return db.ReservationMasters.Count(e => e.PNRNo == id) > 0;
        }
    }
}