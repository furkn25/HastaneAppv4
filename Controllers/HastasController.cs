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
    public class HastasController : Controller
    {
        private readonly HastaneContext _context;

        public HastasController(HastaneContext context)
        {
            _context = context;
        }

        // GET: Hastas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hastalar.ToListAsync());
        }

        // GET: Hastas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hasta = await _context.Hastalar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hasta == null)
            {
                return NotFound();
            }

            return View(hasta);
        }

        // GET: Hastas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hastas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ad,Soyad,DogumTarihi")] Hasta hasta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hasta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hasta);
        }

        // GET: Hastas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hasta = await _context.Hastalar.FindAsync(id);
            if (hasta == null)
            {
                return NotFound();
            }
            return View(hasta);
        }

        // POST: Hastas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ad,Soyad,DogumTarihi")] Hasta hasta)
        {
            if (id != hasta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hasta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HastaExists(hasta.Id))
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
            return View(hasta);
        }

        // GET: Hastas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hasta = await _context.Hastalar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hasta == null)
            {
                return NotFound();
            }

            return View(hasta);
        }

        // POST: Hastas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hasta = await _context.Hastalar.FindAsync(id);
            if (hasta != null)
            {
                _context.Hastalar.Remove(hasta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HastaExists(int id)
        {
            return _context.Hastalar.Any(e => e.Id == id);
        }
    }
}
