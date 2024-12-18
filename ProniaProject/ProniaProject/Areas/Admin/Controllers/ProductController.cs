using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaProject.DAL;
using ProniaProject.ViewModels.Products;

namespace ProniaProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        readonly AppDbContext _context;
        public ProductController(AppDbContext context)
        {
            _context = context; 
        }
        // GET: ProductController
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }
        public IActionResult Create()
        {
            return View(); 
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateVM vm)
        {
             
        }
    }
}
