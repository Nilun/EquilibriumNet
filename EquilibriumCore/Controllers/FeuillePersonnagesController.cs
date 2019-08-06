using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;


using Microsoft.AspNetCore.Mvc;
using EquilibriumCore.Models;
using EquilibriumCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace EquilibriumCore.Controllers
{
    [Authorize]
    public class FeuillePersonnagesController : Controller
    {
        private DataContext db;

        public FeuillePersonnagesController(DataContext datas)
        {
            db = datas;
        }

        // GET: FeuillePersonnages
        public ActionResult Index()
        {

            // User.Identity.Name
            List<FeuillePersonnage> result = db.Feuilles.ToList().Where(a => a.Shared == true || a.Creator == User.Identity.Name).ToList();
            return View(result);
        }

        // GET: FeuillePersonnages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            FeuillePersonnage feuillePersonnage = db.Feuilles.Find(id);
            if (feuillePersonnage == null)
            {
                return NotFound();
            }
            return View(feuillePersonnage);
        }

        // GET: FeuillePersonnages/Create
        public ActionResult Create()
        {
            return   View(new FeuillePersonnage());
        }

        // POST: FeuillePersonnages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("ID,Name,Race,Level,HPPerLevel,HPNow,MemoryBonus,OneHand,LOneHand,TwoHand,Throw,Bow,Body,Parry,Elem,Occult,Primordial,Metamagic,Infusion,Resist,MagicIdentif,Stealth,Survival,Perception,Speech,History,Medic,Empath,Athletism,Acrobatics,Craft,Intimidation,passive,Stuff,comp,Shared")] FeuillePersonnage feuillePersonnage)
        {
            if (ModelState.IsValid)
            {
                feuillePersonnage.Creator = User.Identity.Name;
                db.Feuilles.Add(feuillePersonnage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(feuillePersonnage);
        }

        // GET: FeuillePersonnages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            FeuillePersonnage feuillePersonnage = db.Feuilles.Find(id);
            if (User.Identity.Name != feuillePersonnage.Creator)
            {
                return Forbid();
            }
            if (feuillePersonnage == null )
            {
                return NotFound();
            }
            return View(feuillePersonnage);
        }

        // POST: FeuillePersonnages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("ID,Name,Race,Level,HPPerLevel,HPNow,MemoryBonus,OneHand,LOneHand,TwoHand,Throw,Bow,Body,Parry,Elem,Occult,Primordial,Metamagic,Infusion,Resist,MagicIdentif,Stealth,Survival,Perception,Speech,History,Medic,Empath,Athletism,Acrobatics,Craft,Intimidation,passive,Stuff,comp,Shared")] FeuillePersonnage feuillePersonnage)
        {
            if (ModelState.IsValid)
            {
                feuillePersonnage.Creator = User.Identity.Name;
                db.Feuilles.Update(feuillePersonnage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(feuillePersonnage);
        }

        // GET: FeuillePersonnages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            FeuillePersonnage feuillePersonnage = db.Feuilles.Find(id);
            if (User.Identity.Name != feuillePersonnage.Creator)
            {
                return Forbid();
            }
            if (feuillePersonnage == null )
            {
                return NotFound();
            }
            return View(feuillePersonnage);
        }

        // POST: FeuillePersonnages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FeuillePersonnage feuillePersonnage = db.Feuilles.Find(id);
            db.Feuilles.Remove(feuillePersonnage);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
