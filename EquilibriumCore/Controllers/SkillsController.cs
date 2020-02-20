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
    
    public class SkillsController : Controller
    {
        private readonly DataContext _context;

        public SkillsController(DataContext context)
        {
            _context = context;
        }

        // GET: Skills
        public async Task<IActionResult> Index()
        {
            return View(await _context.Skills.ToListAsync());
        }

        // GET: Skills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skills = await _context.Skills
                .FirstOrDefaultAsync(m => m.ID == id);
            if (skills == null)
            {
                return NotFound();
            }

            return View(skills);
        }

        public async Task<IActionResult> Select(int? FP )
        {
            ViewBag.FP = FP;
            List<string> Tags = new List<string>();
            Tags = _context.Skills.Select((a) => a.Tags).Where((a) => a != null && a != "").ToList();
            Tags = String.Join(' ', Tags).Split(' ',StringSplitOptions.RemoveEmptyEntries).Distinct().ToList();  //.SelectMany(a => a.Split(" ",StringSplitOptions.RemoveEmptyEntries)).Distinct().ToList();
            List<string> Cats = _context.Skills.Select((a) => a.cat).Distinct().ToList();
            List<string> SupCats = _context.Skills.Select((a) => a.superCat).Distinct().ToList();
            ViewBag.Tags = Tags.OrderBy((a) => a);
            ViewBag.Cats = Cats.OrderBy((a)=>a);
            ViewBag.SupCats = SupCats.OrderBy((a) => a);
            return View(await _context.Skills.ToListAsync());
        }
        public async Task<IActionResult> Selected(int? id,int? FP)
        {
                       
            return RedirectToAction("AddSkillsFP", "FeuillePersonnages", new { id = FP });
        }

        // GET: Skills/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Skills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("ID,superCat,cat,Name,Effect,levelMax,Tags")] Skills skills)
        {
            if (ModelState.IsValid)
            {
                string textOld = "";
                string textNew = "Add : " + skills.Name + " - Level : " + skills.levelMax + " - " + skills.Effect;
                if (textOld != textNew)
                {
                    Modification modif = new Modification() { Categorie = "Add", SousCategorie = "Skills - " + skills.superCat, IDUpdate = _context.Update.Where((a) => a.Sortie == _context.Update.Max((b) => b.Sortie)).First().ID };
                    modif.TexteOld = textOld;
                    modif.TexteNew = textNew;
                    _context.Add(modif);
                }
                _context.Add(skills);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(skills);
        }

        // GET: Skills/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skills = await _context.Skills.FindAsync(id);
            if (skills == null)
            {
                return NotFound();
            }
            return View(skills);
        }

        // POST: Skills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("ID,superCat,cat,Name,Effect,levelMax,Tags,Ignore")] Skills skills)
        {
            if (id != skills.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Skills old = _context.Skills.AsNoTracking().First((a) => a.ID == skills.ID);
                    
                    string textOld = "Modification : " + old.Name + " - Level : " + old.levelMax + " - " + old.Effect;
                    string textNew = "Modification : " + skills.Name + " - Level : " + skills.levelMax + " - " + skills.Effect;
                    if(textOld != textNew)
                    {
                        Modification modif = new Modification() { Categorie = "Modification", SousCategorie = "Skills - " + skills.superCat, IDUpdate = _context.Update.Where((a) => a.Sortie == _context.Update.Max((b) => b.Sortie)).First().ID };
                        modif.TexteOld = textOld;
                        modif.TexteNew = textNew;                        
                            _context.Add(modif);
                    }

                    
                    _context.Update(skills);
                    
                    await _context.SaveChangesAsync();
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkillsExists(skills.ID))
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
            return View(skills);
        }

        // GET: Skills/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skills = await _context.Skills
                .FirstOrDefaultAsync(m => m.ID == id);
            if (skills == null)
            {
                return NotFound();
            }

            return View(skills);
        }

        // POST: Skills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Skills old = _context.Skills.AsNoTracking().First((a) => a.ID == id);
            string textOld = "Delete : " + old.Name + " - Level : " + old.levelMax + " - " + old.Effect;
            string textNew = "";
            if (textOld != textNew)
            {
                Modification modif = new Modification() { Categorie = "Delete", SousCategorie = "Skills - " + old.superCat, IDUpdate = _context.Update.Where((a) => a.Sortie == _context.Update.Max((b) => b.Sortie)).First().ID };
                modif.TexteOld = textOld;
                modif.TexteNew = textNew;
                _context.Add(modif);
            }

            var skills = await _context.Skills.FindAsync(id);
            _context.Skills.Remove(skills);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SkillsExists(int id)
        {
            return _context.Skills.Any(e => e.ID == id);
        }
    }
}
