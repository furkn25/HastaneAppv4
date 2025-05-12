using HastaneAppv4.Data;
using HastaneAppv4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HastaneAppv4.Controllers
{
    public class DoktorsController : Controller
    {
        private readonly HastaneContext _context;
        private const int PageSize = 10;
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Doktor doktor)
        {
            if (ModelState.IsValid)
            {
                _context.Doktorlar.Add(doktor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doktor);
        }

        public DoktorsController(HastaneContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString, string bransFilter, int? klinikId, int? page)
        {
            IQueryable<Doktor> query = _context.Doktorlar
                .Include(d => d.Klinik)
                .AsNoTracking();

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(d => d.Ad.Contains(searchString) || d.Soyad.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(bransFilter))
            {
                query = query.Where(d => d.Brans == bransFilter);
            }

            if (klinikId.HasValue)
            {
                query = query.Where(d => d.KlinikId == klinikId);
            }

            ViewData["KlinikId"] = new SelectList(await _context.Klinikler.ToListAsync(), "Id", "Ad");
            ViewBag.Branslar = await _context.Doktorlar.Select(d => d.Brans).Distinct().ToListAsync();

            return View(await PaginatedList<Doktor>.CreateAsync(query.OrderBy(d => d.Ad), page ?? 1, PageSize));

        }
    }
}