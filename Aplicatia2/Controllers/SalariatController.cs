using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aplicatia2.Models;

namespace Aplicatia2.Controllers
{
    public class SalariatController : Controller
    {
        private readonly SalariatContext _context;

        public SalariatController(SalariatContext context)
        {
            _context = context;
        }

        // GET: Salariat
        public async Task<IActionResult> Index()
        {
            return View(await _context.Salariat.ToListAsync());
        }

        // GET: Salariat/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salariat = await _context.Salariat
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salariat == null)
            {
                return NotFound();
            }

            return View(salariat);
        }

        // GET: Salariat/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Salariat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nume,Prenume,Salariu")] Salariat salariat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salariat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salariat);
        }

        // GET: Salariat/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salariat = await _context.Salariat.FindAsync(id);
            if (salariat == null)
            {
                return NotFound();
            }
            return View(salariat);
        }

        // POST: Salariat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nume,Prenume,Salariu")] Salariat salariat)
        {
            if (id != salariat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salariat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalariatExists(salariat.Id))
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
            return View(salariat);
        }

        // GET: Salariat/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salariat = await _context.Salariat
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salariat == null)
            {
                return NotFound();
            }

            return View(salariat);
        }

        // POST: Salariat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salariat = await _context.Salariat.FindAsync(id);
            if (salariat != null)
            {
                _context.Salariat.Remove(salariat);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalariatExists(int id)
        {
            return _context.Salariat.Any(e => e.Id == id);
        }
    }
}
