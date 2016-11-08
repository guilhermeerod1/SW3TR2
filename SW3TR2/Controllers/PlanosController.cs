using SW3TR2.Contexts;
using SW3TR2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SW3TR2.Controllers
{
    public class PlanosController : Controller
    {
        private SQLServerContext context = new SQLServerContext();

        [HttpGet]
        public ActionResult Index()
        {
            return View
                (context.Planos.Include(p => p.Projeto).OrderBy(x => x.Nome));
        }

        [HttpGet]
        public ActionResult Details(long? id)
        {
            UpdateViewBag();
            return Get(id);
        }

        [HttpGet]
        public ActionResult Create()
        {
            UpdateViewBag();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Plano plano)
        {
            plano.Emissao = DateTime.Now;
            
            context.Planos.Add(plano);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(long? id)
        {
            UpdateViewBag();
            return Get(id);
        }

        [HttpPost]
        public ActionResult Edit(Plano plano)
        {
            plano.Emissao = DateTime.Now;

            if (ModelState.IsValid)
            {
                context.Entry(plano).State = EntityState.Modified;
                context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(plano);
        }

        [HttpGet]
        public ActionResult Delete(long? id)
        {
            return Get(id);
        }

        [HttpPost]
        public ActionResult Delete(long id)
        {
            Plano plano = context.Planos.Find(id);

            context.Planos.Remove(plano);
            context.SaveChanges();

            TempData["DeleteMsg"] =

                "O seguinte Plano foi removido: " + plano.Nome;

            return RedirectToAction("Index");
        }

        private ActionResult Get(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Plano plano = 
                
                context
                .Planos
                .Where(p => p.Id == id)
                .Include(pr => pr.Projeto)
                .First();

            if (plano == null) return HttpNotFound();

            return View(plano);
        }

        private void UpdateViewBag()
        {
            ViewBag.ProjetoId = new SelectList
            (
                context.Projetos.OrderBy(x => x.Nome), "Id", "Nome"
            );
        }

    }
}