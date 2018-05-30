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
    public class TeamStatTypesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/TeamStatTypes
        public IQueryable<TeamStatType> GetTeamStatTypes()
        {
            return db.TeamStatTypes;
        }

        // GET: api/TeamStatTypes/5
        [ResponseType(typeof(TeamStatType))]
        public IHttpActionResult GetTeamStatType(int id)
        {
            TeamStatType teamStatType = db.TeamStatTypes.Find(id);
            if (teamStatType == null)
            {
                return NotFound();
            }

            return Ok(teamStatType);
        }

        // PUT: api/TeamStatTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTeamStatType(int id, TeamStatType teamStatType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != teamStatType.Id)
            {
                return BadRequest();
            }

            db.Entry(teamStatType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamStatTypeExists(id))
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

        // POST: api/TeamStatTypes
        [ResponseType(typeof(TeamStatType))]
        public IHttpActionResult PostTeamStatType(TeamStatType teamStatType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TeamStatTypes.Add(teamStatType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = teamStatType.Id }, teamStatType);
        }

        // DELETE: api/TeamStatTypes/5
        [ResponseType(typeof(TeamStatType))]
        public IHttpActionResult DeleteTeamStatType(int id)
        {
            TeamStatType teamStatType = db.TeamStatTypes.Find(id);
            if (teamStatType == null)
            {
                return NotFound();
            }

            db.TeamStatTypes.Remove(teamStatType);
            db.SaveChanges();

            return Ok(teamStatType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TeamStatTypeExists(int id)
        {
            return db.TeamStatTypes.Count(e => e.Id == id) > 0;
        }
    }
}