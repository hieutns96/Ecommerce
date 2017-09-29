using Ecommerce_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Ecommerce_Web.Controllers
{
    [RoutePrefix("api/Login")]
    public class LoginController : ApiController
    {
        AccountHelper acc = new AccountHelper();
        wthEntities db = new wthEntities();
        [HttpPost]
        [Route("Authen")]
        public IHttpActionResult Login(LoginViewModel model)
        {
           // LoginViewModel model = new LoginViewModel();
           // model.user = x;
            if (ModelState.IsValid) // nếu thỏa các điều kiện về điền đầy đủ form, độ dài vv
            {
                int check =  model.CheckAccount(model.user); //NGUOI_DUNG
                if (check == 2) //đã xác thực
                {
                    model.user.EMAIL = db.NGUOI_DUNG.Where(p => p.USERNAME == model.user.USERNAME).SingleOrDefault().EMAIL;
                   
                    return Ok(model.user.USERNAME);
                }
                else if (check == 1) // chưa xác thực
                {
                    return BadRequest("External user is not registered");
                }
                //chưa có tài khoản
                return BadRequest("Invalid Account Access Token");
            }
            else
            {
                return BadRequest("Provider or external access token is not sent");
            }
        }

    }
}
