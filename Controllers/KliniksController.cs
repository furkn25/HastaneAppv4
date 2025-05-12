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
    public class KliniksController : Controller
    {
        private readonly HastaneContext _context;

        public KliniksController(HastaneContext context)
        {
            _context = context;
        }

        // GET: Kliniks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Klinikler.ToListAsync());
        }

        // GET: Kliniks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klinik = await _context.Klinikler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (klinik == null)
            {
                return NotFound();
            }

            return View(klinik);
        }

        // GET: Kliniks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kliniks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ad")] Klinik klinik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(klinik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(klinik);
        }

        // GET: Kliniks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klinik = await _context.Klinikler.FindAsync(id);
            if (klinik == null)
            {
                return NotFound();
            }
            return View(klinik);
        }

        // POST: Kliniks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ad")] Klinik klinik)
        {
            if (id != klinik.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(klinik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KlinikExists(klinik.Id))
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
            return View(klinik);
        }

        // GET: Kliniks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klinik = await _context.Klinikler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (klinik == null)
            {
                return NotFound();
            }

            return View(klinik);
        }

        // POST: Kliniks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var klinik = await _context.Klinikler.FindAsync(id);
            if (klinik != null)
            {
                _context.Klinikler.Remove(klinik);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KlinikExists(int id)
        {
            return _context.Klinikler.Any(e => e.Id == id);
        }
    }
}
