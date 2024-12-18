using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaProject.DAL;
using ProniaProject.Models;
using ProniaProject.ViewModels.Tag;

namespace ProniaProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TagController : Controller
    {
        readonly AppDbContext _context;
        public TagController(AppDbContext context)
        {
            _context = context; 
        }
        // GET: TagController
        public async Task<ActionResult> Index()
        {
            return View(await _context.Tags.ToListAsync());
        }
        public IActionResult Create()
        {
            return View(); 
        }
        [HttpPost]
        public async Task<IActionResult> Create(TagCreateVM vm)
        {
            if (!ModelState.IsValid) return View();

            Tag tag = new Tag
            {
                Name = vm.Name
            };
            await _context.Tags.AddAsync(tag);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index)); 
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var data = await _context.Tags.FindAsync(id);
            if (data == null) return NotFound();
            _context.Tags.Remove(data);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index)); 
        }

        public async Task<IActionResult> ToggleTagVisibility(int? id, bool isDeleted)
        {
            if (!id.HasValue) return BadRequest();
            var data =await _context.Tags.FindAsync(id);
            if (data == null) return NotFound();

            data.IsDeleted = isDeleted;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index)); 
        }
        public async Task<IActionResult> Show(int? id)
        {
            return await ToggleTagVisibility(id, false); 
        }
        public async Task<IActionResult> Hide(int? id)
        {
            return await ToggleTagVisibility(id, true); 
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var data = await _context.Tags
                .Where(x => x.Id == id)
                .Select(x => new TagUpdateVM
                {
                    Name = x.Name
                }).FirstOrDefaultAsync();
            if (data == null) return NotFound();
            return View(data); 
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id, TagUpdateVM vm)
        {
            if (!id.HasValue) return BadRequest();
            var data = await _context.Tags.FindAsync(id);
            if (data == null) return NotFound();

            if (!ModelState.IsValid) return View(vm);
            data.Name = vm.Name;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index)); 
        }
    }
}
