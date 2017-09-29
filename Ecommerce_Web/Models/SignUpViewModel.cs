using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce_Web.Models
{
    public class SignUpViewModel
    {
        AccountHelper acc = new AccountHelper();
      
        wthEntities db = new wthEntities();
    
        public string Username { set; get; }

        public string Email { set; get; }


        public string ReEmail { set; get; }

        public string Password { get; set; }

  
        public string RePassword { get; set; }

     
        public string HO_TEN { get; set; }

        public string DIA_CHI { get; set; }
       
        //tạo tài khoản mới Sign up
        public bool CreateAcc(NGUOI_DUNG x)
        {
            x.BARCODE = acc.RandomString(10);
            try
            {
                db.NGUOI_DUNG.Add(x);
                db.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }   
    }
}