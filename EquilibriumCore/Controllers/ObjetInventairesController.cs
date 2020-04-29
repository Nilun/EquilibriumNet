using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EquilibriumCore.Data;
using EquilibriumCore.Models;
using Microsoft.AspNetCore.Authorization;

namespace EquilibriumCore.Controllers
{
    [Authorize]
    public class ObjetInventairesController : Controller
    {
        private readonly DataContext _context;

        public ObjetInventairesController(DataContext context)
        {
            _context = context;
        }

        // GET: ObjetInventaires
        public async Task<IActionResult> Index()
        {
            return View(await _context.ObjetInventaire.ToListAsync());
        }

        // GET: ObjetInventaires/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objetInventaire = await _context.ObjetInventaire
                .FirstOrDefaultAsync(m => m.ID == id);
            if (objetInventaire == null)
            {
                return NotFound();
            }

            return View(objetInventaire);
        }

        // GET: ObjetInventaires/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ObjetInventaires/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ItemSourceID,CharacterID,TypeObjectIn")] ObjetInventaire objetInventaire)
        {
            if (ModelState.IsValid)
            {
                _context.Add(objetInventaire);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(objetInventaire);
        }

        // GET: ObjetInventaires/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objetInventaire = await _context.ObjetInventaire.FindAsync(id);
            if (objetInventaire == null)
            {
                return NotFound();
            }
            return View(objetInventaire);
        }

        // POST: ObjetInventaires/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ItemSourceID,CharacterID,TypeObjectIn")] ObjetInventaire objetInventaire)
        {
            if (id != objetInventaire.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(objetInventaire);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObjetInventaireExists(objetInventaire.ID))
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
            return View(objetInventaire);
        }

        // GET: ObjetInventaires/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objetInventaire = await _context.ObjetInventaire
                .FirstOrDefaultAsync(m => m.ID == id);
            if (objetInventaire == null)
            {
                return NotFound();
            }

            return View(objetInventaire);
        }

        // POST: ObjetInventaires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var objetInventaire = await _context.ObjetInventaire.FindAsync(id);
            _context.ObjetInventaire.Remove(objetInventaire);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObjetInventaireExists(int id)
        {
            return _context.ObjetInventaire.Any(e => e.ID == id);
        }
    }
}
