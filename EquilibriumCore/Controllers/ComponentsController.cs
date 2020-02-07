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
    public class ComponentsController : Controller
    {
        private readonly DataContext _context;

        public ComponentsController(DataContext context)
        {
            _context = context;
        }

        // GET: Components
        public async Task<IActionResult> Index()
        {
            return View(await _context.Component.ToListAsync());
        }

        // GET: Components/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var component = await _context.Component
                .FirstOrDefaultAsync(m => m.ID == id);
            if (component == null)
            {
                return NotFound();
            }

            return View(component);
        }

        // GET: Components/Create
        public IActionResult Create()
        {
            return View(new Component());
        }

        // POST: Components/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,name,Element,PriceString,IsForm,Range,Area,text,valuesString,upgradesString")] Component component)
        {
            if (ModelState.IsValid)
            {
                string textOld = "";
                string textNew = "Add : " + component.name + " -  : " + component.Element + " - " + component.getFusedStringForDescription();
                if (textOld != textNew)
                {
                    Modification modif = new Modification() { Categorie = "Add", SousCategorie = "Component - " + component.Element.ToString(), IDUpdate = _context.Update.Where((a) => a.Sortie == _context.Update.Max((b) => b.Sortie)).First().ID };
                    modif.TexteOld = textOld;
                    modif.TexteNew = textNew;
                    _context.Add(modif);
                }
                _context.Add(component);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(component);
        }

        // GET: Components/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var component = await _context.Component.FindAsync(id);
            if (component == null)
            {
                return NotFound();
            }
            return View(component);
        }

        // POST: Components/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,name,Element,PriceString,IsForm,Range,Area,text,valuesString,upgradesString")] Component component)
        {
            if (id != component.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Component old = _context.Component.AsNoTracking().First((a) => a.ID == component.ID);

                    string textOld = "Modification : " + old.name + " -  : " + old.Element + " - " + old.getFusedStringForDescription();
                    string textNew = "Modification : " + component.name + " -  : " + component.Element + " - " + component.getFusedStringForDescription();
                    if (textOld != textNew)
                    {
                        Modification modif = new Modification() { Categorie = "Modification", SousCategorie = "Component - " + component.Element.ToString(), IDUpdate = _context.Update.Where((a) => a.Sortie == _context.Update.Max((b) => b.Sortie)).First().ID };
                        modif.TexteOld = textOld;
                        modif.TexteNew = textNew;
                        _context.Add(modif);
                    }

                    _context.Update(component);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComponentExists(component.ID))
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
            return View(component);
        }

        // GET: Components/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var component = await _context.Component
                .FirstOrDefaultAsync(m => m.ID == id);
            if (component == null)
            {
                return NotFound();
            }

            return View(component);
        }

        // POST: Components/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Component old = _context.Component.AsNoTracking().First((a) => a.ID == id);

            string textOld = "Delete : " + old.name + " -  : " + old.Element + " - " + old.getFusedStringForDescription();
            string textNew = "";
            if (textOld != textNew)
            {
                Modification modif = new Modification() { Categorie = "Delete", SousCategorie = "Component - " + old.Element.ToString(), IDUpdate = _context.Update.Where((a) => a.Sortie == _context.Update.Max((b) => b.Sortie)).First().ID };
                modif.TexteOld = textOld;
                modif.TexteNew = textNew;
                _context.Add(modif);
            }
            var component = await _context.Component.FindAsync(id);
            _context.Component.Remove(component);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComponentExists(int id)
        {
            return _context.Component.Any(e => e.ID == id);
        }
    }
}
