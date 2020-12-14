using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcUser.Models;

namespace MvcUser.Controllers
{
    public class PersonalController : Controller
    {
        private readonly UserContext _context;

        public PersonalController(UserContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Edit(int? id)
        {
            UserPageModel usermodel = new UserPageModel();
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            usermodel.Id = user.Id;
            usermodel.UserName = user.UserName;
            usermodel.PassWord = user.PassWord;
            usermodel.Gender = user.Gender;
            usermodel.Age = user.Age;
            usermodel.Provinces = user.Provinces;
            usermodel.FileUrl = "../../Image/" + Path.GetFileName(user.Image);
            usermodel.Url = user.Url;
            if (user == null)
            {
                return NotFound();
            }

            return View(usermodel);
        }

        // POST: Personal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,PassWord,Gender,Age,Provinces,City,Image,Url")] UserPageModel usermodel)
        {
            if (id != usermodel.Id)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            user.Id = usermodel.Id;
            user.UserName = usermodel.UserName;
            user.PassWord = usermodel.PassWord;
            user.Gender = usermodel.Gender;
            user.Age = usermodel.Age;
            user.Provinces = usermodel.Provinces;
            user.City = usermodel.City;
            string fileUrl = Guid.NewGuid().ToString() + ".png";
            usermodel.FileUrl = "../../Image/" + fileUrl;
            var path = Directory.GetCurrentDirectory();
            if (usermodel.Image != null)
            {
                using (FileStream fs = new FileStream(path + @"\wwwroot\Image\" + fileUrl, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    var memoryStream = new MemoryStream();

                    await usermodel.Image.CopyToAsync(memoryStream);


                    byte[] bytes = memoryStream.ToArray();
                    fs.Write(bytes, 0, bytes.Length);
                    user.Image = path + @"\wwwroot\Image\" + fileUrl;
                }


            }
            user.Url = usermodel.Url;
            if (!ModelState.IsValid)
            {
                _context.Update(user);
                await _context.SaveChangesAsync();
                return View("Index");
            }
            return View(user);
        }
    }
}
