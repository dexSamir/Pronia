using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using ProniaProject.DAL;
using ProniaProject.Models;
using ProniaProject.Utilities.Extensions;
using ProniaProject.ViewModels.Slider;

namespace ProniaProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        readonly AppDbContext _context;
        readonly IWebHostEnvironment _env;
        public SliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env; 
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Sliders.ToListAsync()); 
        }

        public IActionResult Create()
        {
            return View(); 
        }
        [HttpPost]
        public async Task<IActionResult> Create(SliderCreateVM vm)
        {
            if(vm.File == null || vm.File.Length == 0)
            {
                ModelState.AddModelError("File", "File is required");
                return View(vm); 
            }
            if (!vm.File.isValidType("image"))
            {
                ModelState.AddModelError("File", "File type must be an image");
                return View(); 
            }
            if (!vm.File.isValidSize(300))
            {
                ModelState.AddModelError("File", "File size must be less than 300kb");
                return View(); 
            }    

            string fileName = await vm.File.UploadAsync(_env.WebRootPath, "imgs", "sliders");

            Slider slider = new Slider
            {
                Title = vm.Title,
                Subtitle = vm.Subtitle,
                ImageUrl = fileName,
                Offer = vm.Offer
            };
            await _context.AddAsync(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index)); 
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var data = await _context.Sliders.FindAsync(id);
            if (data == null) return NotFound();
            string path = Path.Combine(Directory.GetCurrentDirectory(),_env.WebRootPath, "imgs", "sliders", data.ImageUrl);
            if (System.IO.Directory.Exists(path))
                System.IO.Directory.Delete(path); 
            _context.Sliders.Remove(data);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index)); 
        }
        public async Task<IActionResult> ToggleSlideVisibility(int? id, bool isDeleted)
        {
            if (!id.HasValue) return BadRequest();
            var data = await _context.Sliders.FindAsync(id);
            if (data == null) return NotFound();

            data.IsDeleted = isDeleted;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index)); 
        }
        public async Task<IActionResult> Show(int? id)
        {
            return await ToggleSlideVisibility(id, true);
        }
        public async Task<IActionResult> Hide (int? id)
        {
            return await ToggleSlideVisibility(id, true); 
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var slider = _context.Sliders
                .Where(x => id == x.Id)
                .Select(x => new SliderUpdateVM
                {
                    Title = x.Title,
                    ImageUrl = x.ImageUrl,
                    Offer = x.Offer,
                    Subtitle = x.Subtitle 
                }).FirstOrDefault();
            if (slider == null) return NotFound(); 
            return View(slider); 
        }
        [HttpPost]
        public async Task<IActionResult> Index(int? id, SliderUpdateVM vm)
        {
            if (!id.HasValue) return BadRequest();
            var data = await _context.Sliders.FindAsync(id);
            if (data == null) return NotFound();

            if (!ModelState.IsValid) return View(vm);

            if(vm.File !=null)
            {
                if(vm.File.isValidType("image"))
                {
                    ModelState.AddModelError("File", "File type must be and image!");
                    return View(vm); 
                }
                if(vm.File.isValidSize(300))
                {
                    ModelState.AddModelError("File", "File size must be less than 300kb!");
                    return View(vm); 
                }
                string OldPath = Path.Combine(Directory.GetCurrentDirectory(), _env.WebRootPath, "imgs", "sliders", data.ImageUrl);

                if (System.IO.File.Exists(OldPath))
                    System.IO.File.Delete(OldPath);

                string newFileName = await vm.File.UploadAsync(_env.WebRootPath, "imgs", "sliders");
                data.ImageUrl = newFileName;
                
            }

            data.Title = vm.Title;
            data.Subtitle = vm.Subtitle;
            data.Offer = vm.Offer;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index)); 
        }
    }
}
