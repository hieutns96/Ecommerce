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
using System.Web;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.IO;

namespace Ecommerce_Web.Controllers
{
   
    public class SachController : ApiController
    {
        private wthEntities db = new wthEntities();

        // GET api/Sach
       // lay het sach
      
       [Route("api/Sach")]
        public IQueryable<SACH> GetSACHes()
        {
            return db.SACHes;
        }
      
       
        // GET api/Sach/GetBestSeller
        public IHttpActionResult GetBestSeller()
        {
            return Ok(db.SACHes.OrderByDescending(p => p.SOLUOTMUA).Select(p => p).Take(9));
        }

        
        
        // GET api/Sach/GetNewBooks
        public IHttpActionResult GetNewBooks()
        {
            return Ok(db.SACHes.OrderByDescending(p => p.NGAY_NHAP).Select(p => p).Take(9));
        }


        // GET api/Sach/5
        [ResponseType(typeof(SACH))]

        public IHttpActionResult GetSACH(long id)
        {
            SACH sach = db.SACHes.Find(id);
            if (sach == null)
            {
                return NotFound();
            }

            return Ok(sach);
        }

        // PUT api/Sach/5
        
        
        public IHttpActionResult PutSACH(long id, SACH sach)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sach.MA_SACH)
            {
                return BadRequest();
            }

            db.Entry(sach).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
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

        // POST api/Sach
      
      
        [ResponseType(typeof(SACH))]
        public IHttpActionResult PostSACH(SACH sach)
        {


            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }
            else
            {
                var task = this.Request.Content.ReadAsStreamAsync();
                task.Wait();
                Stream requestStream = task.Result;

                try
                {
                    string filename = sach.TEN_SACH;
                    Stream fileStream = File.Create(HttpContext.Current.Server.MapPath("~/" + filename));
                    requestStream.CopyTo(fileStream);
                    fileStream.Close();
                    requestStream.Close();
                }
                catch (IOException)
                {
                    throw new HttpResponseException(HttpStatusCode.InternalServerError);
                }

                HttpResponseMessage response = new HttpResponseMessage();
                response.StatusCode = HttpStatusCode.Created;
                db.SACHes.Add(sach);
                db.SaveChanges();

                return CreatedAtRoute("DefaultApi", new { id = sach.MA_SACH }, sach);
            }


        }




        // DELETE api/Sach/5
  
       
        [ResponseType(typeof(SACH))]
        public IHttpActionResult DeleteSACH(long id)
        {
            SACH sach = db.SACHes.Find(id);
            if (sach == null)
            {
                return NotFound();
            }

            db.SACHes.Remove(sach);
            db.SaveChanges();

            return Ok(sach);
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