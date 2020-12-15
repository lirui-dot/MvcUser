using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcUser.Models;

namespace MvcUser.Controllers
{
    public class ProvinceController : Controller
    {
        private readonly UserContext _context;
        public ProvinceController(UserContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> PostProvince()
        {
            var dbProvince = await _context.Provinces.Where(m => m.id < 35).ToListAsync();
            if (dbProvince != null)
            {
                return Json(dbProvince);
            }
            return Json(dbProvince);
        }
        public async Task<ActionResult> GetCity(int? parentid){
            var dbCity=await _context.Provinces.Where(m=>m.parentid==parentid).ToListAsync();
            if(dbCity!=null){
                return Json(dbCity);
            }
            return Json(dbCity);
        }
    }
}