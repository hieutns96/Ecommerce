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
    public class NHA_XUAT_BANController : ApiController
    {
        private wthEntities db = new wthEntities();

        // GET: api/NHA_XUAT_BAN
        public IQueryable<NHA_XUAT_BAN> GetNHA_XUAT_BAN()
        {
            return db.NHA_XUAT_BAN;
        }

        // GET: api/NHA_XUAT_BAN/5
        [ResponseType(typeof(NHA_XUAT_BAN))]
        public async Task<IHttpActionResult> GetNHA_XUAT_BAN(long id)
        {
            NHA_XUAT_BAN nHA_XUAT_BAN = await db.NHA_XUAT_BAN.FindAsync(id);
            if (nHA_XUAT_BAN == null)
            {
                return NotFound();
            }

            return Ok(nHA_XUAT_BAN);
        }

        // PUT: api/NHA_XUAT_BAN/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutNHA_XUAT_BAN(long id, NHA_XUAT_BAN nHA_XUAT_BAN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nHA_XUAT_BAN.MA_NXB)
            {
                return BadRequest();
            }

            db.Entry(nHA_XUAT_BAN).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NHA_XUAT_BANExists(id))
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

        // POST: api/NHA_XUAT_BAN
        [ResponseType(typeof(NHA_XUAT_BAN))]
        public async Task<IHttpActionResult> PostNHA_XUAT_BAN(NHA_XUAT_BAN nHA_XUAT_BAN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NHA_XUAT_BAN.Add(nHA_XUAT_BAN);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = nHA_XUAT_BAN.MA_NXB }, nHA_XUAT_BAN);
        }

        // DELETE: api/NHA_XUAT_BAN/5
        [ResponseType(typeof(NHA_XUAT_BAN))]
        public async Task<IHttpActionResult> DeleteNHA_XUAT_BAN(long id)
        {
            NHA_XUAT_BAN nHA_XUAT_BAN = await db.NHA_XUAT_BAN.FindAsync(id);
            if (nHA_XUAT_BAN == null)
            {
                return NotFound();
            }

            db.NHA_XUAT_BAN.Remove(nHA_XUAT_BAN);
            await db.SaveChangesAsync();

            return Ok(nHA_XUAT_BAN);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NHA_XUAT_BANExists(long id)
        {
            return db.NHA_XUAT_BAN.Count(e => e.MA_NXB == id) > 0;
        }
    }
}