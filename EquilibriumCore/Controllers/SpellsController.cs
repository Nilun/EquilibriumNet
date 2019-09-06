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
    public class SpellsController : Controller
    {
        private readonly DataContext _context;

        public SpellsController(DataContext context)
        {
            _context = context;
        }

        // GET: Spells
        public async Task<IActionResult> Index()
        {
            return View(await _context.Spell.ToListAsync());
        }

        // GET: Spells/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spell = await _context.Spell.Include(s => s.LinkComponents).ThenInclude(l => l.Component)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (spell == null)
            {
                return NotFound();
            }
            spell.AllComponents = _context.Component.ToList();
            return View(spell);
        }

        // GET: Spells/Create
        public IActionResult Create(int? id)
        {
           
            if (id == null) id = 0;   
            List<Component> all = _context.Component.ToList();
            return View(new Spell() { AllComponents = all, IDCaster = (int)id });
        }

        // POST: Spells/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("name,Element,IDForm,listID,IDComponents,IDCaster")] Spell spell)
        {
            if (ModelState.IsValid)
            {
                spell.AllComponents = _context.Component.ToList();
                spell.FillForeignKey();
                _context.Add(spell);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(spell);
        }

        // GET: Spells/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spell = await _context.Spell.FindAsync(id);
            if (spell == null)
            {
                return NotFound();
            }
            return View(spell);
        }

        // POST: Spells/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Element,IDForm,listID,IDComponents")] Spell spell)
        {
            if (id != spell.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spell);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpellExists(spell.ID))
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
            return View(spell);
        }

        // GET: Spells/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spell = await _context.Spell
                .FirstOrDefaultAsync(m => m.ID == id);
            if (spell == null)
            {
                return NotFound();
            }

            return View(spell);
        }

        // POST: Spells/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var spell = await _context.Spell.FindAsync(id);
            _context.Spell.Remove(spell);
            _context.SpellLinkComponent.RemoveRange(_context.SpellLinkComponent.Include(a=>a.Spell).Where(a=>a.Spell.ID==id));
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpellExists(int id)
        {
            return _context.Spell.Any(e => e.ID == id);
        }
    }
}
