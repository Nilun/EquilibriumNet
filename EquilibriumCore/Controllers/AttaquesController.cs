using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EquilibriumCore.Data;
using EquilibriumCore.Models;

namespace EquilibriumCore.Controllers
{
    public class AttaquesController : Controller
    {
        private readonly DataContext _context;

        public AttaquesController(DataContext context)
        {
            _context = context;
        }

        // GET: Attaques
        public async Task<IActionResult> Index()
        {
            return View(await _context.Attaque.ToListAsync());
        }

        // GET: Attaques/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attaque = await _context.Attaque
                .FirstOrDefaultAsync(m => m.ID == id);
            if (attaque == null)
            {
                return NotFound();
            }

            return View(attaque);
        }

        // GET: Attaques/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Attaques/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,name,Portée,Type,Description,User")] Attaque attaque)
        {
            if (ModelState.IsValid)
            {
                _context.Add(attaque);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(attaque);
        }

        // GET: Attaques/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attaque = await _context.Attaque.FindAsync(id);
            if (attaque == null)
            {
                return NotFound();
            }
            return View(attaque);
        }

        // POST: Attaques/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,name,Portée,Type,Description,User")] Attaque attaque)
        {
            if (id != attaque.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attaque);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttaqueExists(attaque.ID))
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
            return View(attaque);
        }

        // GET: Attaques/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attaque = await _context.Attaque
                .FirstOrDefaultAsync(m => m.ID == id);
            if (attaque == null)
            {
                return NotFound();
            }

            return View(attaque);
        }

        // POST: Attaques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var attaque = await _context.Attaque.FindAsync(id);
            _context.Attaque.Remove(attaque);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AttaqueExists(int id)
        {
            return _context.Attaque.Any(e => e.ID == id);
        }
    }
}
