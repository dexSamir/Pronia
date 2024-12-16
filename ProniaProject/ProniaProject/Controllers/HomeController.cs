using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaProject.DAL;
using ProniaProject.ViewModels.Common;
using ProniaProject.ViewModels.Slider;

namespace ProniaProject.Controllers
{
    public class HomeController : Controller
    {
        readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context; 
        }

        // GET: HomeController
        public async Task<ActionResult> Index()
        {
            HomeVM vm = new HomeVM(); 
            vm.Sliders =await _context.Sliders
                .Where(x => !x.IsDeleted)
                .Select(x => new SliderItemVM
            {
                Title = x.Title,
                Subtitle = x.Subtitle,
                Offer = x.Offer,
                ImageUrl = x.ImageUrl
            }).ToListAsync();

            return View(vm); 
        }
    }
}
