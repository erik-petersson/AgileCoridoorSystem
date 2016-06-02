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
using CorridorSystem.Models;
using CorridorSystem.Models.DAL;
using System.Security.Claims;

namespace CorridorSystem.Controllers
{
    public class EventController : ApiController
    {
        private ModelContext db = new ModelContext();

        // GET: api/Event
        public IQueryable<eventModel> Getevents()
        {
            return db.events;
        }

        // GET: api/Event/5
        [ResponseType(typeof(eventModel))]
        public IHttpActionResult GeteventModel(int id)
        {
            eventModel eventModel = db.events.Find(id);
            if (eventModel == null)
            {
                return NotFound();
            }

            return Ok(eventModel);
        }

        // PUT: api/Event/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuteventModel(int id, eventModel eventModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eventModel.Id)
            {
                return BadRequest();
            }

            db.Entry(eventModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!eventModelExists(id))
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

        // POST: api/Event
        [ResponseType(typeof(eventModel))]
        public IHttpActionResult PosteventModel(eventModel eventModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ClaimsIdentity claimsIdentity = (ClaimsIdentity)User.Identity;
            Claim userClaim = claimsIdentity.FindFirst(ClaimTypes.Name);
            string myUsername = userClaim.Value;

            var user = db.MyUsers.Include(u => u.schedule.events).FirstOrDefault(u => u.UserName == myUsername);

            if (user.schedule.events == null)
            {
                user.schedule.events = new List<eventModel>();
            }

            eventModel.DTStamp = DateTime.Now;
            eventModel.LastModified = DateTime.Now;
            user.schedule.events.Add(eventModel);

            // db.events.Add(eventModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = eventModel.Id }, eventModel);
        }

        // DELETE: api/Event/5
        [ResponseType(typeof(eventModel))]
        public IHttpActionResult DeleteeventModel(int id)
        {
            eventModel eventModel = db.events.Find(id);
            if (eventModel == null)
            {
                return NotFound();
            }

            db.events.Remove(eventModel);
            db.SaveChanges();

            return Ok(eventModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool eventModelExists(int id)
        {
            return db.events.Count(e => e.Id == id) > 0;
        }
    }
}