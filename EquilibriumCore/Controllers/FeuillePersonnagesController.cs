﻿using System;
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

using System.IO;
using jsreport.AspNetCore;
using jsreport.Types;
using CoreHtmlToImage;

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
            List<int> partieMJ = db.Partie.Where(p => p.MJ == User.Identity.Name).Select(p => p.ID).ToList();
            List<FeuillePersonnage> result = db.Feuilles.ToList().Where(a => a.Shared == true || a.Creator == User.Identity.Name || partieMJ.Contains(a.IDPartie)).ToList();
            result.ForEach(a => a.partie = db.Partie.Where(p => p.ID == a.IDPartie).First().Name);
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
            feuillePersonnage.Spells = db.Spell.Include(c => c.LinkComponents).ThenInclude(l => l.Component)
                .Where(s => s.IDCaster == feuillePersonnage.ID).ToList();
           
           
            return View(feuillePersonnage);
        }

        public List<Partie> getParties()
        {
            List<Partie> result = db.Partie.ToList();
            return result;
        }
        // GET: FeuillePersonnages/Create
        public ActionResult Create()
        {
            return   View(new FeuillePersonnage() { partiePossible=getParties() });
        }

        // POST: FeuillePersonnages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("ID,Name,Race,Level,HPPerLevel,HPNow,MemoryBonus,OneHand,LOneHand,TwoHand,Throw,Bow,Body,Parry,Elem,Occult,Primordial,Metamagic,Infusion,Resist,MagicIdentif,Stealth,Survival,Perception,Speech,History,Medic,Empath,Athletism,Acrobatics,CraftB,CraftSW,CraftS,CraftM,Intimidation,passive,Stuff,comp,partie,Shared")] FeuillePersonnage feuillePersonnage)
        {
            if (ModelState.IsValid)
            {
                feuillePersonnage.IDPartie = db.Partie.Where(a => a.Name == feuillePersonnage.partie).First().ID;
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
            feuillePersonnage.partiePossible =  getParties();            
            feuillePersonnage.partie = db.Partie.Where(a => a.ID == feuillePersonnage.IDPartie).FirstOrDefault().Name;
            return View(feuillePersonnage);
        }

        // POST: FeuillePersonnages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("ID,Name,Race,Level,HPPerLevel,HPNow,MemoryBonus,OneHand,LOneHand,TwoHand,Throw,Bow,Body,Parry,Elem,Occult,Primordial,Metamagic,Infusion,Resist,MagicIdentif,Stealth,Survival,Perception,Speech,History,Medic,Empath,Athletism,Acrobatics,CraftB,CraftSW,CraftS,CraftM,Intimidation,passive,Stuff,comp,partie,Shared")] FeuillePersonnage feuillePersonnage)
        {
            if (ModelState.IsValid)
            {
                feuillePersonnage.IDPartie = db.Partie.Where(a => a.Name == feuillePersonnage.partie).First().ID;
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


        [MiddlewareFilter(typeof(JsReportPipeline))]
        [AllowAnonymous]
        public IActionResult DetailPdf(int id)
        {
            HttpContext.JsReportFeature().Recipe(Recipe.ChromePdf);



         
            FeuillePersonnage feuillePersonnage = db.Feuilles.Find(id);
            if (feuillePersonnage == null)
            {
                return NotFound();
            }
            feuillePersonnage.Spells = db.Spell.Include(c => c.LinkComponents).ThenInclude(l => l.Component)
                .Where(s => s.IDCaster == feuillePersonnage.ID).ToList();
            feuillePersonnage.showHidable = false;

            return View("Details" , feuillePersonnage);
        }

        public ActionResult CreateImage(int id)
        {

        

            HtmlConverter converter = new HtmlConverter();

            var bytes = converter.FromUrl("https://equilibrium.jupotter.eu/spells/Details/1");
            // var bytes = converter.FromHtmlString("test");

            return File(bytes, "image/png", true);

        }
        [AllowAnonymous]
        public ActionResult CreateSpellCard(int id)
        {
                      

            HtmlConverter converter = new HtmlConverter();
            string s = "https://equilibrium.jupotter.eu/spells/Card/"+id;
            //string s = "https://localhost:44310/spells/Card/"+id;
            var bytes = converter.FromUrl(s,370);
            // var bytes = converter.FromHtmlString("test");

            return File(bytes, "image/png", true);

        }
    }
}
