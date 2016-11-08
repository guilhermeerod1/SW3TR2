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
    public class ProjetosController : Controller
    {
        private SQLServerContext context = new SQLServerContext();
        
        [HttpGet]
        public ActionResult Index()
        {
            return View(context.Projetos.OrderBy(x => x.Nome));
        }
        
        [HttpGet]
        public ActionResult Details(long? id)
        {
            return Get(id);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Projeto projeto)
        {
            projeto.Emissao = DateTime.Now;

            context.Projetos.Add(projeto);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public ActionResult Edit(long? id)
        {
            return Get(id);
        }
        
        [HttpPost]
        public ActionResult Edit(Projeto projeto)
        {
            projeto.Emissao = DateTime.Now;

            if (ModelState.IsValid)
            {
                context.Entry(projeto).State = EntityState.Modified;
                context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(projeto);
        }
        
        [HttpGet]
        public ActionResult Delete(long? id)
        {
            return Get(id);
        }
        
        [HttpPost]
        public ActionResult Delete(long id)
        {
            Projeto projeto = context.Projetos.Find(id);

            context.Projetos.Remove(projeto);
            context.SaveChanges();

            TempData["DeleteMsg"] =

                "O seguinte Projeto foi removido: " + projeto.Nome;

            return RedirectToAction("Index");
        }

        private ActionResult Get(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Projeto projeto = context.Projetos.Find(id);

            if (projeto == null) return HttpNotFound();

            return View(projeto);
        }
        
    }
}