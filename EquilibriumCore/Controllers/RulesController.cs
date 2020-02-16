﻿using System;
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
   
    public class RulesController : Controller
    {
        private readonly DataContext _context;

        public RulesController(DataContext context)
        {
            _context = context;
        }

        // GET: Rules
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rules.ToListAsync());
        }

        // GET: Rules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rules = await _context.Rules
                .FirstOrDefaultAsync(m => m.ID == id);
            if (rules == null)
            {
                return NotFound();
            }

            return View(rules);
        }

        // GET: Rules/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("ID,Category,IsTitle,Text")] Rules rules)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rules);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rules);
        }

        // GET: Rules/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rules = await _context.Rules.FindAsync(id);
            if (rules == null)
            {
                return NotFound();
            }
            return View(rules);
        }

        // POST: Rules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Category,IsTitle,Text")] Rules rules)
        {
            if (id != rules.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rules);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RulesExists(rules.ID))
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
            return View(rules);
        }

        // GET: Rules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rules = await _context.Rules
                .FirstOrDefaultAsync(m => m.ID == id);
            if (rules == null)
            {
                return NotFound();
            }

            return View(rules);
        }

        // POST: Rules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rules = await _context.Rules.FindAsync(id);
            _context.Rules.Remove(rules);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RulesExists(int id)
        {
            return _context.Rules.Any(e => e.ID == id);
        }

        public async Task<IActionResult> MainRules(int? id)
        {
            return View(Tuple.Create( _context.Rules.ToList(),id.HasValue?_context.Rules.FirstOrDefault(val=>val.ID==id.Value):null));
        }
    }
}
