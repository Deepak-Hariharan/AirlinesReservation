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
    public class FlightSchedulesController : ApiController
    {
        private AssignmentDBEntities db = new AssignmentDBEntities();

        // GET: api/FlightSchedules
        public IQueryable<FlightSchedule> GetFlightSchedules()
        {
            return db.FlightSchedules;
        }

        // GET: api/FlightSchedules/5
        [ResponseType(typeof(FlightSchedule))]
        public IHttpActionResult GetFlightSchedule(string id)
        {
            FlightSchedule flightSchedule = db.FlightSchedules.Find(id);
            if (flightSchedule == null)
            {
                return NotFound();
            }

            return Ok(flightSchedule);
        }

        // PUT: api/FlightSchedules/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFlightSchedule(string id, FlightSchedule flightSchedule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != flightSchedule.FlightNo)
            {
                return BadRequest();
            }

            db.Entry(flightSchedule).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightScheduleExists(id))
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

        // POST: api/FlightSchedules
        [ResponseType(typeof(FlightSchedule))]
        public IHttpActionResult PostFlightSchedule(FlightSchedule flightSchedule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FlightSchedules.Add(flightSchedule);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (FlightScheduleExists(flightSchedule.FlightNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = flightSchedule.FlightNo }, flightSchedule);
        }

        // DELETE: api/FlightSchedules/5
        [ResponseType(typeof(FlightSchedule))]
        public IHttpActionResult DeleteFlightSchedule(string id)
        {
            FlightSchedule flightSchedule = db.FlightSchedules.Find(id);
            if (flightSchedule == null)
            {
                return NotFound();
            }

            db.FlightSchedules.Remove(flightSchedule);
            db.SaveChanges();

            return Ok(flightSchedule);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FlightScheduleExists(string id)
        {
            return db.FlightSchedules.Count(e => e.FlightNo == id) > 0;
        }
    }
}