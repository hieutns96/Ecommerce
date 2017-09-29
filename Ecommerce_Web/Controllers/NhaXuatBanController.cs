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
using Ecommerce_Web;

namespace Ecommerce_Web.Controllers
{
    public class NhaXuatBanController : ApiController
    {
        private wthEntities db = new wthEntities();

        // GET api/NhaXuatBan
         [Route("api/NhaXuatBan")]
        public IQueryable<NHA_XUAT_BAN> GetNHA_XUAT_BAN()
        {
            return db.NHA_XUAT_BAN;
        }

        // GET api/NhaXuatBan/5
        [ResponseType(typeof(NHA_XUAT_BAN))]
        public IHttpActionResult GetNHA_XUAT_BAN(long id)
        {
            NHA_XUAT_BAN nha_xuat_ban = db.NHA_XUAT_BAN.Find(id);
            if (nha_xuat_ban == null)
            {
                return NotFound();
            }

            return Ok(nha_xuat_ban);
        }

        // PUT api/NhaXuatBan/5
        public IHttpActionResult PutNHA_XUAT_BAN(long id, NHA_XUAT_BAN nha_xuat_ban)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nha_xuat_ban.MA_NXB)
            {
                return BadRequest();
            }

            db.Entry(nha_xuat_ban).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
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

        // POST api/NhaXuatBan
        [ResponseType(typeof(NHA_XUAT_BAN))]
        public IHttpActionResult PostNHA_XUAT_BAN(NHA_XUAT_BAN nha_xuat_ban)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NHA_XUAT_BAN.Add(nha_xuat_ban);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = nha_xuat_ban.MA_NXB }, nha_xuat_ban);
        }

        // DELETE api/NhaXuatBan/5
        [ResponseType(typeof(NHA_XUAT_BAN))]
        public IHttpActionResult DeleteNHA_XUAT_BAN(long id)
        {
            NHA_XUAT_BAN nha_xuat_ban = db.NHA_XUAT_BAN.Find(id);
            if (nha_xuat_ban == null)
            {
                return NotFound();
            }

            db.NHA_XUAT_BAN.Remove(nha_xuat_ban);
            db.SaveChanges();

            return Ok(nha_xuat_ban);
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