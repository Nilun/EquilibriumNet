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

using System.IO;
using jsreport.AspNetCore;
using jsreport.Types;
using CoreHtmlToImage;
using Newtonsoft.Json;
using Microsoft.Extensions.Caching.Memory;

namespace EquilibriumCore.Controllers
{
    [Authorize]
    public class FeuillePersonnagesController : Controller
    {
        private DataContext db;
        IMemoryCache memory;

        public FeuillePersonnagesController(DataContext datas , IMemoryCache cache)
        {
            db = datas;
            memory = cache;
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
            feuillePersonnage.tipspells = db.Tooltiper.ToList();
            if (feuillePersonnage.skills != null)
            {
                string[] splited = feuillePersonnage.skills.Split(';',StringSplitOptions.RemoveEmptyEntries);
                //feuillePersonnage.ListSkills = db.Skills.Where((a) => splited.Contains(a.ID.ToString())).ToList();
                feuillePersonnage.ListSkills = splited.Select((a) => db.Skills.Find(int.Parse(a))).ToList();
                feuillePersonnage.calculateLevelOfSkills();
            }
            feuillePersonnage.partie = db.Partie.Where(a => a.ID == feuillePersonnage.IDPartie).First().Name;
            feuillePersonnage.partiePossible = getParties();
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

        public ActionResult AddSkillsFP(int? SkillId, int? id)
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
            feuillePersonnage.skills += SkillId + ";";
            db.Feuilles.Update(feuillePersonnage);
            db.SaveChanges();
            return RedirectToAction("Details", new { id = id });
        }
        public ActionResult RemoveSkillsFP(int? SkillId, int? id)
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
            var nl = feuillePersonnage.skills.Split(";").ToList();
           nl.Remove(SkillId.ToString());
            feuillePersonnage.skills = String.Join(';',nl) + ";";
            db.Feuilles.Update(feuillePersonnage);
            db.SaveChanges();
            return RedirectToAction("Details", new { id = id });
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
                return RedirectToAction("Details", new { id = feuillePersonnage.ID });
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

            if (!memory.TryGetValue<Tuple<Byte[], ReportMeta>>("f" + id, out var result))
            {

                HttpContext.JsReportFeature().Recipe(Recipe.ChromePdf);
                HttpContext.JsReportFeature().OnAfterRender((r) =>
                {
                    MemoryStream ms = new MemoryStream();
                    r.Content.CopyTo(ms);
                    var rep = Tuple.Create(ms.ToArray(), r.Meta);
                    memory.Set("f" + id, rep, TimeSpan.FromMinutes(10));
                    ms.Dispose();
                    r.Content.Seek(0, SeekOrigin.Begin);
                });



                FeuillePersonnage feuillePersonnage = db.Feuilles.Find(id);
                if (feuillePersonnage == null)
                {
                    return NotFound();
                }
                feuillePersonnage.Spells = db.Spell.Include(c => c.LinkComponents).ThenInclude(l => l.Component)
                    .Where(s => s.IDCaster == feuillePersonnage.ID).ToList();
                feuillePersonnage.showHidable = false;

                return View("Details", feuillePersonnage);
            }
            HttpContext.JsReportFeature().Enabled = false;
            return File(result.Item1, result.Item2.ContentType);
        }

        public ActionResult CreateImage(int id)
        {

        

            HtmlConverter converter = new HtmlConverter();

            var bytes = converter.FromUrl("https://equilibrium.jupotter.eu/spells/Details/1");
            // var bytes = converter.FromHtmlString("test");

            return File(bytes, "image/png", true);

        }

        [MiddlewareFilter(typeof(JsReportPipeline))]
        [AllowAnonymous]        
        public ActionResult CreateSpellCard(int id)
        {
           
            if(!memory.TryGetValue<Tuple<Byte[],ReportMeta>>("s"+id , out var result))
            { 

            HttpContext.JsReportFeature().Recipe(Recipe.ChromeImage).Configure(a => a.Template.ChromeImage = new ChromeImage() { OmitBackground = false , ClipHeight = 550, ClipX=0,ClipY=0, ClipWidth=375});
            HttpContext.JsReportFeature().OnAfterRender((r) =>
                                                               {
                                                                   MemoryStream ms = new MemoryStream();
                                                                   r.Content.CopyTo(ms);
                                                                   var rep = Tuple.Create(ms.ToArray(),r.Meta) ;
                                                                   memory.Set("s" + id,rep, TimeSpan.FromMinutes(10));
                                                                   ms.Dispose();
                                                                   r.Content.Seek(0, SeekOrigin.Begin);
                                                                });
            HtmlConverter converter = new HtmlConverter();
          
            var sp = db.Spell.Include(c=>c.LinkComponents).ThenInclude(l => l.Component).First(c => c.ID == id);
            return View("../Spells/Card",sp);
            }
            HttpContext.JsReportFeature().Enabled = false;
            return File( result.Item1 ,result.Item2.ContentType );

        }
        [AllowAnonymous]
        public ActionResult SpellList(int id)
        {
            string res = JsonConvert.SerializeObject(db.Spell.Where(a => a.IDCaster == id).Select(a=>a.ID).ToArray());
            return View("SpellList",res);
        }
       


    }
}
