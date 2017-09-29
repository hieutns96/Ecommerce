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
    public class SACHesController : ApiController
    {
        private wthEntities db = new wthEntities();

        // GET: api/SACHes
        [Authorize]
        [Route("api/Sach")]
        public IQueryable<SACH> GetSACHes()
        {
            return db.SACHes;
        }

        [Route("api/Sach/BestSeller")]
        // GET api/Sach/GetBestSeller
        public IHttpActionResult GetBestSeller()
        {
            return Ok(db.SACHes.OrderByDescending(p => p.SOLUOTMUA).Select(p => p).Take(9));
        }


        [Route("api/Sach/NewBooks")]
        // GET api/Sach/GetNewBooks
        public IHttpActionResult GetNewBooks()
        {
            return Ok(db.SACHes.OrderByDescending(p => p.NGAY_NHAP).Select(p => p).Take(9));
        }



        // GET: api/SACHes/5
        [ResponseType(typeof(SACH))]
        public async Task<IHttpActionResult> GetSACH(long id)
        {
            SACH sACH = await db.SACHes.FindAsync(id);
            if (sACH == null)
            {
                return NotFound();
            }

            return Ok(sACH);
        }

        // PUT: api/SACHes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSACH(long id, SACH sACH)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sACH.MA_SACH)
            {
                return BadRequest();
            }

            db.Entry(sACH).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SACHExists(id))
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

        // POST: api/SACHes
        [ResponseType(typeof(SACH))]
        public async Task<IHttpActionResult> PostSACH(SACH sACH)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SACHes.Add(sACH);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = sACH.MA_SACH }, sACH);
        }

        // DELETE: api/SACHes/5
        [ResponseType(typeof(SACH))]
        public async Task<IHttpActionResult> DeleteSACH(long id)
        {
            SACH sACH = await db.SACHes.FindAsync(id);
            if (sACH == null)
            {
                return NotFound();
            }

            db.SACHes.Remove(sACH);
            await db.SaveChangesAsync();

            return Ok(sACH);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SACHExists(long id)
        {
            return db.SACHes.Count(e => e.MA_SACH == id) > 0;
        }
    }
}