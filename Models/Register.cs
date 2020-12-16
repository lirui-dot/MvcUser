using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace MvcUser.Models
{
    public class Register
    {
        public int Id { get; set; }
        [Remote(action: "NameIsExists", controller: "User")]
       
        [Display(Name = "用户名")]
        [Required(ErrorMessage = "请输入{0}")]
        public string userName { get; set; }

        [Display(Name = "密码")]
        [Required(ErrorMessage = "请输入{0}")]
        public string passWord { get; set; }

        [Required(ErrorMessage = "请再次输入密码")]
        [Display(Name = "确认密码")]
        [Compare("passWord", ErrorMessage = "两次密码不一样")]
        public string cpassWord { get; set; }

    }
}
