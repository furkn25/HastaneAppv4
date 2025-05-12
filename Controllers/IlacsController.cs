using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HastaneAppv4.Data;
using HastaneAppv4.Models;

namespace HastaneAppv4.wwwroot
{
    public class IlacsController : Controller
    {
        private readonly HastaneContext _context;

        public IlacsController(HastaneContext context)
        {
            _context = context;
        }

        // GET: Ilacs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ilaclar.ToListAsync());
        }

        // GET: Ilacs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ilac = await _context.Ilaclar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ilac == null)
            {
                return NotFound();
            }

            return View(ilac);
        }

        // GET: Ilacs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ilacs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ad,Aciklama")] Ilac ilac)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ilac);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ilac);
        }

        // GET: Ilacs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ilac = await _context.Ilaclar.FindAsync(id);
            if (ilac == null)
            {
                return NotFound();
            }
            return View(ilac);
        }

        // POST: Ilacs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ad,Aciklama")] Ilac ilac)
        {
            if (id != ilac.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ilac);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IlacExists(ilac.Id))
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
            return View(ilac);
        }

        // GET: Ilacs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ilac = await _context.Ilaclar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ilac == null)
            {
                return NotFound();
            }

            return View(ilac);
        }

        // POST: Ilacs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ilac = await _context.Ilaclar.FindAsync(id);
            if (ilac != null)
            {
                _context.Ilaclar.Remove(ilac);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IlacExists(int id)
        {
            return _context.Ilaclar.Any(e => e.Id == id);
        }
    }
}
