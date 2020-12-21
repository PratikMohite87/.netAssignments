using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_ASP.NET_App2.Models
{
   
    public class UserDetails
    {
        public int UserId { set; get; }

        [Required(ErrorMessage = "Please enter login Name")]
        public String UserLoginName { set; get; }

        [Required(ErrorMessage = "Please enter Password")]
        public String UserPassword { set; get; }
        public String UserFullName { set; get; }
        public String UserEmailId { set; get; }
        public String UserMobileNo { set; get; }
        public IEnumerable<SelectListItem> UserCity { set; get; }
        public int UserCityNo { set; get; }
        public bool Remeberme { set; get; }
        public String City { set; get; }
    }
}