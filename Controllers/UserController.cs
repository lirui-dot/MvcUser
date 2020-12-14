using Microsoft.AspNetCore.Mvc;
using MvcUser.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MvcUser.Controllers
{
    public class UserController : Controller
    {
        private readonly UserContext _context;
        public UserController(UserContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(User user)
        {
            if (ModelState.IsValid)
            {
              
                var dbuser = _context.Users.FirstOrDefault(m => m.UserName.Equals(user.UserName) && m.PassWord.Equals(user.PassWord));
                    
                if (dbuser != null)
                {
                    return RedirectToAction("Edit", "Personal", new { id = dbuser.Id });
                }   
                else
                    return View();
            }
            return View(user);
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Register register)
        {
           
            User user = new User();
            user.UserName = register.userName;
            user.PassWord = register.passWord;
            user.CpassWord = register.cpassWord;
            if (user != null)
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }
    }
}
