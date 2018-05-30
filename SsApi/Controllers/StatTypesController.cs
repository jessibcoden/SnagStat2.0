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
    public class StatTypesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/StatTypes
        public IQueryable<StatType> GetStatTypes()
        {
            return db.StatTypes;
        }

        // GET: api/StatTypes/5
        [ResponseType(typeof(StatType))]
        public IHttpActionResult GetStatType(int id)
        {
            StatType statType = db.StatTypes.Find(id);
            if (statType == null)
            {
                return NotFound();
            }

            return Ok(statType);
        }

        // PUT: api/StatTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStatType(int id, StatType statType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != statType.Id)
            {
                return BadRequest();
            }

            db.Entry(statType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatTypeExists(id))
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

        // POST: api/StatTypes
        [ResponseType(typeof(StatType))]
        public IHttpActionResult PostStatType(StatType statType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StatTypes.Add(statType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = statType.Id }, statType);
        }

        // DELETE: api/StatTypes/5
        [ResponseType(typeof(StatType))]
        public IHttpActionResult DeleteStatType(int id)
        {
            StatType statType = db.StatTypes.Find(id);
            if (statType == null)
            {
                return NotFound();
            }

            db.StatTypes.Remove(statType);
            db.SaveChanges();

            return Ok(statType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StatTypeExists(int id)
        {
            return db.StatTypes.Count(e => e.Id == id) > 0;
        }
    }
}