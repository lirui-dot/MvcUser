using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace MvcUser.Models
{
    public class User
    {
        public int Id { get; set; }
        [Display(Name = "用户名")]
        [Required(ErrorMessage = "请输入{0}")]
        public string UserName { get; set; }
        [Display(Name = "密码")]
        [Required(ErrorMessage = "请输入{0}")]
        public string PassWord { get; set; }
        [NotMapped]
        // [Required(ErrorMessage = "请再次输入密码")]
        // [Display(Name = "确认密码")]
        // [Compare("passWord", ErrorMessage = "两次密码不一样")]
        public string CpassWord { get; set; }
        // [Display(Name = "性别")]
        // [Required(ErrorMessage = "请输入{0}")]
        public char Gender { get; set; }
        // [Display(Name = "年龄")]
        // [Required(ErrorMessage = "请输入{0}")]
        public int Age { get; set; }
        // [Display(Name = "省份")]
        // [Required(ErrorMessage = "请输入{0}")]
        public int Provinces { get; set; }
        // [Display(Name = "城市")]
        // [Required(ErrorMessage = "请输入{0}")]
        public int City { get; set; }
        // [Display(Name = "图片")]
        public string Image { get; set; }
        // [Display(Name = "个人网址")]
        // [Required]
        // [Url]
        public string Url { get; set; }

    }
}