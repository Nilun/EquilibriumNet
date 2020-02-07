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
    public class TooltipersController : Controller
    {
        private readonly DataContext _context;

        public TooltipersController(DataContext context)
        {
            _context = context;
        }

        // GET: Tooltipers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tooltiper.ToListAsync());
        }

        // GET: Tooltipers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tooltiper = await _context.Tooltiper
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tooltiper == null)
            {
                return NotFound();
            }

            return View(tooltiper);
        }

        // GET: Tooltipers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tooltipers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,keyword,tooltiptext")] Tooltiper tooltiper)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tooltiper);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tooltiper);
        }

        // GET: Tooltipers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tooltiper = await _context.Tooltiper.FindAsync(id);
            if (tooltiper == null)
            {
                return NotFound();
            }
            return View(tooltiper);
        }

        // POST: Tooltipers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,keyword,tooltiptext")] Tooltiper tooltiper)
        {
            if (id != tooltiper.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tooltiper);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TooltiperExists(tooltiper.ID))
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
            return View(tooltiper);
        }

        // GET: Tooltipers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tooltiper = await _context.Tooltiper
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tooltiper == null)
            {
                return NotFound();
            }

            return View(tooltiper);
        }

        // POST: Tooltipers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tooltiper = await _context.Tooltiper.FindAsync(id);
            _context.Tooltiper.Remove(tooltiper);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TooltiperExists(int id)
        {
            return _context.Tooltiper.Any(e => e.ID == id);
        }
    }
}
