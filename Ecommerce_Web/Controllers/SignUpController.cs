using Ecommerce_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ecommerce_Web.Controllers
{
    [RoutePrefix("api/SignUp")]
    public class SignUpController : ApiController
    {
        AccountHelper acc = new AccountHelper();
        wthEntities db = new wthEntities();
        [HttpPost]
        [Route("")]
        public IHttpActionResult Register(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                string password = acc.md5(model.Password);
                //chưa  tạo mã ngẫu nhiên
                NGUOI_DUNG user = new NGUOI_DUNG { USERNAME = model.Username, PASSWORD = password, EMAIL = model.Email, IDQH = 1, XACTHUC = 1, HO_TEN = model.HO_TEN, DIA_CHI = model.DIA_CHI };
                  
                if (model.CreateAcc(user) == true)//đã tiến hành tạo
                {
                    //gửi thông tin đăng ký cho user
                    AccountHelper a = new AccountHelper();
                    string subject = "Hi Hoàng " + user.USERNAME;
                    string body = String.Format("Tài khoản của bạn có Username là {0}, Password là {1}, Mã xác nhận là {2}, Link xác nhận {3}"
                        , user.USERNAME, model.Password, user.BARCODE, "localhost/SignUp/AfterSignUp");
                    a.SendMail(user.EMAIL, subject, body);

                    return Ok();
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc email đã tồn tại!");
                    return BadRequest(ModelState);
                }
            }
            else
            {
                ModelState.AddModelError("", "Thông tin đăng ký không hợp lệ");
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        [Route("AfterSignUp")]
        public IHttpActionResult AfterSignUp(ConfirmSignUpVMD model)
        {
            try
            {
                wthEntities db = new wthEntities();
                string str = model.Barcode;
                NGUOI_DUNG user = db.NGUOI_DUNG.Where(p => p.USERNAME == model.Username && p.EMAIL == model.Email).SingleOrDefault();
                if (acc.CheckBarCode(model.Username, model.Email, model.Barcode) == true && user != null)
                {
                    return Ok();
                }
                else
                {
                    ModelState.AddModelError("", "Thông tin vừa điền không hợp lệ");
                    return BadRequest(ModelState);
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Thông tin vừa điền không hợp lệ");
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        [Route("ForgotPass")]
        public IHttpActionResult ForgotPass(ResetPassVMD model)
        {
            if (ModelState.IsValid)
            {
                if (acc.CheckResetPass(model.Username, model.Email) == true)
                {
                    string newpass = db.NGUOI_DUNG.Where(p => p.USERNAME == model.Username).SingleOrDefault().PASSWORD;
                    db.NGUOI_DUNG.Where(p => p.USERNAME == model.Username).SingleOrDefault().PASSWORD = acc.md5(newpass);
                    db.SaveChanges();
                    string subject = "Rosie Million Store: Reset Password";
                    string body = "Chào " + model.Username + "Mật khẩu mới của bạn là: " + newpass;
                    acc.SendMail(model.Email, subject, body);
                    return Ok();
                }
                ModelState.AddModelError("", "Thông tin điền vào không hợp lệ");
                return BadRequest(ModelState);
            }
            else
            {
                ModelState.AddModelError("", "Email, tên đăng nhập không tồn tại.");
                return BadRequest(ModelState);
            }
        }
    }
}
