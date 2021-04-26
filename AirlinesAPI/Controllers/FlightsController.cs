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
    public class FlightsController : ApiController
    {
        private AssignmentDBEntities db = new AssignmentDBEntities();

        // GET: api/Flights
        public IQueryable<Flight> GetFlights()
        {
            return db.Flights;
        }

        // GET: api/Flights/5
        [ResponseType(typeof(Flight))]
        public IHttpActionResult GetFlight(string id)
        {
            Flight flight = db.Flights.Find(id);
            if (flight == null)
            {
                return NotFound();
            }

            return Ok(flight);
        }

        // PUT: api/Flights/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFlight(string id, Flight flight)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != flight.FlightNo)
            {
                return BadRequest();
            }

            db.Entry(flight).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightExists(id))
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

        // POST: api/Flights
        [ResponseType(typeof(Flight))]
        public IHttpActionResult PostFlight(Flight flight)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Flights.Add(flight);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (FlightExists(flight.FlightNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = flight.FlightNo }, flight);
        }

        // DELETE: api/Flights/5
        [ResponseType(typeof(Flight))]
        public IHttpActionResult DeleteFlight(string id)
        {
            Flight flight = db.Flights.Find(id);
            if (flight == null)
            {
                return NotFound();
            }

            db.Flights.Remove(flight);
            db.SaveChanges();

            return Ok(flight);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FlightExists(string id)
        {
            return db.Flights.Count(e => e.FlightNo == id) > 0;
        }
    }
}