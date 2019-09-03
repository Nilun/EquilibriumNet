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
    public class PartiesController : Controller
    {
        private readonly DataContext _context;

        public PartiesController(DataContext context)
        {
            _context = context;
        }

        // GET: Parties
        public async Task<IActionResult> Index()
        {
            return View(await _context.Partie.ToListAsync());
        }

        // GET: Parties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partie = await _context.Partie
                .FirstOrDefaultAsync(m => m.ID == id);
            if (partie == null)
            {
                return NotFound();
            }

            return View(partie);
        }

        // GET: Parties/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Parties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,MJ,Joueurs")] Partie partie)
        {
            partie.MJ = User.Identity.Name;
            if (ModelState.IsValid)
            {
                _context.Add(partie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(partie);
        }

        // GET: Parties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partie = await _context.Partie.FindAsync(id);
            if (partie == null)
            {
                return NotFound();
            }
            return View(partie);
        }

        // POST: Parties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,MJ,Joueurs")] Partie partie)
        {
            if (id != partie.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartieExists(partie.ID))
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
            return View(partie);
        }

        // GET: Parties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partie = await _context.Partie
                .FirstOrDefaultAsync(m => m.ID == id);
            if (partie == null)
            {
                return NotFound();
            }

            return View(partie);
        }

        // POST: Parties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var partie = await _context.Partie.FindAsync(id);
            _context.Partie.Remove(partie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartieExists(int id)
        {
            return _context.Partie.Any(e => e.ID == id);
        }
    }
}
