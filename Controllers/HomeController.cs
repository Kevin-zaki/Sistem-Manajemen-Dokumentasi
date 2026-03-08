using Microsoft.AspNetCore.Mvc;
using latihan.Data;
using latihan.Models;

namespace latihan.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var profile = _context.Profiles.FirstOrDefault() ?? new ProfileModel
            {
                Name = "Nama Instansi",
                Title = "Slogan Anda",
                AboutMe = "Isi melalui admin."
            };
            return View(profile);
        }
    }
}