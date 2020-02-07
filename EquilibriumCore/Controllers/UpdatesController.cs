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
using Microsoft.AspNetCore.Identity;
using EquilibriumCore.Areas.Identity.Data;

namespace EquilibriumCore.Controllers
{
    public class UpdatesController : Controller
    {
        private readonly DataContext _context;
        private UserManager<EquilibriumCoreUser> userManager;
        public UpdatesController(DataContext context,UserManager<EquilibriumCoreUser> usermanager)
        {
            userManager = usermanager;
            _context = context;
        }

        // GET: Updates
        public async Task<IActionResult> Index()
        {       
             

            List<Update> res = await _context.Update.OrderByDescending((a)=>a.Sortie).ToListAsync();
                       res.ForEach((up) => up.modifications = _context.Modification
            .Where((mod) => mod.IDUpdate == up.ID)
            .OrderBy((a)=>a.Categorie)
            .ThenBy((a)=>a.SousCategorie)
            .ToList());
            return View(res);
        }

        // GET: Updates/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var update = await _context.Update
                .FirstOrDefaultAsync(m => m.ID == id);
            if (update == null)
            {
                return NotFound();
            }

            return View(update);
        }

        // GET: Updates/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Updates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("ID,Name,Description,Sortie")] Update update)
        {
            if (ModelState.IsValid)
            {
                _context.Add(update);
                await _context.SaveChangesAsync();
                               return RedirectToAction(nameof(Index));
            }

            return View(update);
        }

        // GET: Updates/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var update = await _context.Update.FindAsync(id);
            if (update == null)
            {
                return NotFound();
            }
            return View(update);
        }

        // POST: Updates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Description,Sortie")] Update update)
        {
            if (id != update.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(update);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UpdateExists(update.ID))
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
            return View(update);
        }

        // GET: Updates/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var update = await _context.Update
                .FirstOrDefaultAsync(m => m.ID == id);
            if (update == null)
            {
                return NotFound();
            }

            return View(update);
        }

        // POST: Updates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var update = await _context.Update.FindAsync(id);
            _context.Update.Remove(update);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UpdateExists(int id)
        {
            return _context.Update.Any(e => e.ID == id);
        }
    }
}
