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

namespace CorridorSystem.Controllers
{
    public class scheduleController : ApiController
    {
        private ModelContext db = new ModelContext();

        // GET: api/schedule
        public IQueryable<scheduleModel> Getschedule()
        {
            return db.schedule.Include("events");
        }

        // GET: api/schedule?update=5
        public void GetUpdateSchedule(int update)
        {
            db.schedule.Include("events").FirstOrDefault(s => s.Id == update).updateSchedule();
            db.SaveChanges();
        }

        // GET: api/schedule/5
        [ResponseType(typeof(scheduleModel))]
        public IHttpActionResult GetscheduleModel(int id)
        {
            scheduleModel scheduleModel = db.schedule.Include("events").Where(x => x.Id == id).FirstOrDefault<scheduleModel>();
            if (scheduleModel == null)
            {
                return NotFound();
            }

            return Ok(scheduleModel);
        }

        // PUT: api/schedule/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutscheduleModel(int id, scheduleModel scheduleModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != scheduleModel.Id)
            {
                return BadRequest();
            }

            db.Entry(scheduleModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!scheduleModelExists(id))
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

        // POST: api/schedule
        [ResponseType(typeof(scheduleModel))]
        public IHttpActionResult PostscheduleModel(scheduleModel scheduleModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.schedule.Add(scheduleModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = scheduleModel.Id }, scheduleModel);
        }

        // DELETE: api/schedule/5
        [ResponseType(typeof(scheduleModel))]
        public IHttpActionResult DeletescheduleModel(int id)
        {
            scheduleModel scheduleModel = db.schedule.Find(id);
            if (scheduleModel == null)
            {
                return NotFound();
            }

            db.schedule.Remove(scheduleModel);
            db.SaveChanges();

            return Ok(scheduleModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool scheduleModelExists(int id)
        {
            return db.schedule.Count(e => e.Id == id) > 0;
        }
    }
}