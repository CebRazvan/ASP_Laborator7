using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aplicatia1.Models;

namespace Aplicatia1.Controllers
{
    public class ElevController : Controller
    {
        private readonly ElevContext _context;

        public ElevController(ElevContext context)
        {
            _context = context;
        }

        // GET: Elev
        public async Task<IActionResult> Index()
        {
            return View(await _context.Elevi.ToListAsync());
        }

        // GET: Elev/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var elev = await _context.Elevi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (elev == null)
            {
                return NotFound();
            }

            return View(elev);
        }

        // GET: Elev/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Elev/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nume,Prenume,Grupa,NotaMedie")] Elev elev)
        {
            if (ModelState.IsValid)
            {
                _context.Add(elev);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(elev);
        }

        // GET: Elev/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var elev = await _context.Elevi.FindAsync(id);
            if (elev == null)
            {
                return NotFound();
            }
            return View(elev);
        }

        // POST: Elev/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nume,Prenume,Grupa,NotaMedie")] Elev elev)
        {
            if (id != elev.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(elev);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ElevExists(elev.Id))
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
            return View(elev);
        }

        // GET: Elev/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var elev = await _context.Elevi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (elev == null)
            {
                return NotFound();
            }

            return View(elev);
        }

        // POST: Elev/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var elev = await _context.Elevi.FindAsync(id);
            if (elev != null)
            {
                _context.Elevi.Remove(elev);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ElevExists(int id)
        {
            return _context.Elevi.Any(e => e.Id == id);
        }
    }
}
