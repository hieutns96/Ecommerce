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
    public class DanhMucController : ApiController
    {
        private wthEntities db = new wthEntities();

        // GET api/DanhMuc
        [Route("api/DanhMuc")]
        public IQueryable<DANH_MUC> GetDANH_MUC()
        {
            return db.DANH_MUC;
        }

        // GET api/DanhMuc/5
        [ResponseType(typeof(DANH_MUC))]
        public IHttpActionResult GetDANH_MUC(long id)
        {
            DANH_MUC danh_muc = db.DANH_MUC.Find(id);
            if (danh_muc == null)
            {
                return NotFound();
            }

            return Ok(danh_muc);
        }

        // PUT api/DanhMuc/5
        public IHttpActionResult PutDANH_MUC(long id, DANH_MUC danh_muc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != danh_muc.MA_DM)
            {
                return BadRequest();
            }

            db.Entry(danh_muc).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
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

        // POST api/DanhMuc
        [ResponseType(typeof(DANH_MUC))]
        public IHttpActionResult PostDANH_MUC(DANH_MUC danh_muc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DANH_MUC.Add(danh_muc);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = danh_muc.MA_DM }, danh_muc);
        }

        // DELETE api/DanhMuc/5
        [ResponseType(typeof(DANH_MUC))]
        public IHttpActionResult DeleteDANH_MUC(long id)
        {
            DANH_MUC danh_muc = db.DANH_MUC.Find(id);
            if (danh_muc == null)
            {
                return NotFound();
            }

            db.DANH_MUC.Remove(danh_muc);
            db.SaveChanges();

            return Ok(danh_muc);
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