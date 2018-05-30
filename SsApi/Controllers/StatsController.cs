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
using SsApi.Models;
using SsApi.Models.DataModels;

namespace SsApi.Controllers
{
    public class StatsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Stats
        public IQueryable<Stat> GetStats()
        {
            return db.Stats;
        }

        // GET: api/Stats/5
        [ResponseType(typeof(Stat))]
        public IHttpActionResult GetStat(int id)
        {
            Stat stat = db.Stats.Find(id);
            if (stat == null)
            {
                return NotFound();
            }

            return Ok(stat);
        }

        // PUT: api/Stats/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStat(int id, Stat stat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stat.Id)
            {
                return BadRequest();
            }

            db.Entry(stat).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatExists(id))
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

        // POST: api/Stats
        [ResponseType(typeof(Stat))]
        public IHttpActionResult PostStat(Stat stat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Stats.Add(stat);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = stat.Id }, stat);
        }

        // DELETE: api/Stats/5
        [ResponseType(typeof(Stat))]
        public IHttpActionResult DeleteStat(int id)
        {
            Stat stat = db.Stats.Find(id);
            if (stat == null)
            {
                return NotFound();
            }

            db.Stats.Remove(stat);
            db.SaveChanges();

            return Ok(stat);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StatExists(int id)
        {
            return db.Stats.Count(e => e.Id == id) > 0;
        }
    }
}