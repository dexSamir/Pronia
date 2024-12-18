using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaProject.DAL;
using ProniaProject.Models;
using ProniaProject.ViewModels.Category;

namespace ProniaProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        readonly AppDbContext _context;
        public CategoryController(AppDbContext context)
        {
            _context = context; 
        }
        // GET: CategoryController
        public async  Task<ActionResult> Index()
        {
            return View(await _context.Categories.ToListAsync());
        }

        public IActionResult Create()
        {
            return View(); 
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateVM vm)
        {
            if (!ModelState.IsValid) return View();
            Category category = new Category
            {
                Name = vm.Name
            };
            await _context.AddAsync(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index)); 
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var data = await _context.Categories.FindAsync(id);
            if (data == null) return NotFound();

            _context.Categories.Remove(data);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index)); 
        }

        public async Task<IActionResult> ToggleCategoryVisibility(int? id, bool isDeleted)
        {
            if (!id.HasValue) return BadRequest();
            var data = await _context.Categories.FindAsync(id);
            if (data == null) return NotFound();

            data.IsDeleted = isDeleted;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index)); 
        }
        public async Task<IActionResult> Show(int? id)
        {
            return await ToggleCategoryVisibility(id, false);
        }
        public async Task<IActionResult> Hide(int? id)
        {
            return await ToggleCategoryVisibility(id, true); 
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var data = await _context.Categories
                .Where(x => x.Id == id)
                .Select(x => new CategoryUpdateVM
                {
                    Name = x.Name
                }).FirstOrDefaultAsync();

            if (data == null) return NotFound();
            return View(data); 
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id, CategoryUpdateVM vm)
        {
            if (!id.HasValue) return BadRequest();
            var data = await _context.Categories.FindAsync(id);
            if (data == null) return NotFound();
            if (!ModelState.IsValid) return View(vm);

            data.Name = vm.Name;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index)); 
        }
    }
}
