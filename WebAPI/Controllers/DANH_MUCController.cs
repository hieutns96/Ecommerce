using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI;

namespace WebAPI.Controllers
{
    public class DANH_MUCController : ApiController
    {
        private wthEntities db = new wthEntities();

        // GET: api/DANH_MUC
        public IQueryable<DANH_MUC> GetDANH_MUC()
        {
            return db.DANH_MUC;
        }

        // GET: api/DANH_MUC/5
        [ResponseType(typeof(DANH_MUC))]
        public async Task<IHttpActionResult> GetDANH_MUC(long id)
        {
            DANH_MUC dANH_MUC = await db.DANH_MUC.FindAsync(id);
            if (dANH_MUC == null)
            {
                return NotFound();
            }

            return Ok(dANH_MUC);
        }

        // PUT: api/DANH_MUC/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDANH_MUC(long id, DANH_MUC dANH_MUC)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dANH_MUC.MA_DM)
            {
                return BadRequest();
            }

            db.Entry(dANH_MUC).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DANH_MUCExists(id))
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

        // POST: api/DANH_MUC
        [ResponseType(typeof(DANH_MUC))]
        public async Task<IHttpActionResult> PostDANH_MUC(DANH_MUC dANH_MUC)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DANH_MUC.Add(dANH_MUC);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = dANH_MUC.MA_DM }, dANH_MUC);
        }

        // DELETE: api/DANH_MUC/5
        [ResponseType(typeof(DANH_MUC))]
        public async Task<IHttpActionResult> DeleteDANH_MUC(long id)
        {
            DANH_MUC dANH_MUC = await db.DANH_MUC.FindAsync(id);
            if (dANH_MUC == null)
            {
                return NotFound();
            }

            db.DANH_MUC.Remove(dANH_MUC);
            await db.SaveChangesAsync();

            return Ok(dANH_MUC);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DANH_MUCExists(long id)
        {
            return db.DANH_MUC.Count(e => e.MA_DM == id) > 0;
        }
    }
}