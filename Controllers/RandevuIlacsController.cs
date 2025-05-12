using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HastaneAppv4.Data;
using HastaneAppv4.Models;

namespace HastaneAppv4.Controllers
{
    public class RandevuIlacsController : Controller
    {
        private readonly HastaneContext _context;

        public RandevuIlacsController(HastaneContext context)
        {
            _context = context;
        }

        // GET: RandevuIlacs
        public async Task<IActionResult> Index()
        {
            var hastaneContext = _context.RandevuIlaclar.Include(r => r.Ilac).Include(r => r.Randevu);
            return View(await hastaneContext.ToListAsync());
        }

        // GET: RandevuIlacs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var randevuIlac = await _context.RandevuIlaclar
                .Include(r => r.Ilac)
                .Include(r => r.Randevu)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (randevuIlac == null)
            {
                return NotFound();
            }

            return View(randevuIlac);
        }

        // GET: RandevuIlacs/Create
        public IActionResult Create()
        {
            ViewData["IlacId"] = new SelectList(_context.Ilaclar, "Id", "Id");
            ViewData["RandevuId"] = new SelectList(_context.Randevular, "Id", "Id");
            return View();
        }

        // POST: RandevuIlacs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RandevuId,IlacId")] RandevuIlac randevuIlac)
        {
            if (ModelState.IsValid)
            {
                _context.Add(randevuIlac);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IlacId"] = new SelectList(_context.Ilaclar, "Id", "Id", randevuIlac.IlacId);
            ViewData["RandevuId"] = new SelectList(_context.Randevular, "Id", "Id", randevuIlac.RandevuId);
            return View(randevuIlac);
        }

        // GET: RandevuIlacs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var randevuIlac = await _context.RandevuIlaclar.FindAsync(id);
            if (randevuIlac == null)
            {
                return NotFound();
            }
            ViewData["IlacId"] = new SelectList(_context.Ilaclar, "Id", "Id", randevuIlac.IlacId);
            ViewData["RandevuId"] = new SelectList(_context.Randevular, "Id", "Id", randevuIlac.RandevuId);
            return View(randevuIlac);
        }

        // POST: RandevuIlacs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RandevuId,IlacId")] RandevuIlac randevuIlac)
        {
            if (id != randevuIlac.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(randevuIlac);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RandevuIlacExists(randevuIlac.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IlacId"] = new SelectList(_context.Ilaclar, "Id", "Id", randevuIlac.IlacId);
            ViewData["RandevuId"] = new SelectList(_context.Randevular, "Id", "Id", randevuIlac.RandevuId);
            return View(randevuIlac);
        }

        // GET: RandevuIlacs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var randevuIlac = await _context.RandevuIlaclar
                .Include(r => r.Ilac)
                .Include(r => r.Randevu)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (randevuIlac == null)
            {
                return NotFound();
            }

            return View(randevuIlac);
        }

        // POST: RandevuIlacs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var randevuIlac = await _context.RandevuIlaclar.FindAsync(id);
            if (randevuIlac != null)
            {
                _context.RandevuIlaclar.Remove(randevuIlac);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RandevuIlacExists(int id)
        {
            return _context.RandevuIlaclar.Any(e => e.Id == id);
        }
    }
}
