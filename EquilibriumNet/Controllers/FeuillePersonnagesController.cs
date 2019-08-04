using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EquilibriumNet.Data;
using EquilibriumNet.Models;

namespace EquilibriumNet.Controllers
{
    public class FeuillePersonnagesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: FeuillePersonnages
        public ActionResult Index()
        {
            return View(db.Feuilles.ToList());
        }

        // GET: FeuillePersonnages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeuillePersonnage feuillePersonnage = db.Feuilles.Find(id);
            if (feuillePersonnage == null)
            {
                return HttpNotFound();
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
        public ActionResult Create([Bind(Include = "ID,Name,Race,Level,HPPerLevel,HPNow,MemoryBonus,OneHand,LOneHand,TwoHand,Throw,Bow,Body,Parry,Elem,Occult,Primordial,Metamagic,Infusion,Resist,MagicIdentif,Stealth,Survival,Perception,Speech,History,Medic,Empath,Athletism,Acrobatics,Craft,Intimidation,passive")] FeuillePersonnage feuillePersonnage)
        {
            if (ModelState.IsValid)
            {
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
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeuillePersonnage feuillePersonnage = db.Feuilles.Find(id);
            if (feuillePersonnage == null)
            {
                return HttpNotFound();
            }
            return View(feuillePersonnage);
        }

        // POST: FeuillePersonnages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Race,Level,HPPerLevel,HPNow,MemoryBonus,OneHand,LOneHand,TwoHand,Throw,Bow,Body,Parry,Elem,Occult,Primordial,Metamagic,Infusion,Resist,MagicIdentif,Stealth,Survival,Perception,Speech,History,Medic,Empath,Athletism,Acrobatics,Craft,Intimidation,passive")] FeuillePersonnage feuillePersonnage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feuillePersonnage).State = EntityState.Modified;
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
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeuillePersonnage feuillePersonnage = db.Feuilles.Find(id);
            if (feuillePersonnage == null)
            {
                return HttpNotFound();
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
