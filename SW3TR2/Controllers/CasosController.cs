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
    public class CasosController : Controller
    {
        private SQLServerContext context = new SQLServerContext();

        // GET: Casos
        public ActionResult Index()
        {
            return View(context.Casos.Include(p => p.Plano).OrderBy(x => x.Nome));
        }

        // GET: Casos/Details/5
        public ActionResult Details(long? id)
        {
            return Get(id);
        }

        // GET: Casos/Create
        public ActionResult Create()
        {
            UpdateViewBag();
            return View();
        }

        // POST: Casos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Caso caso)
        {
            try
            {
                caso.Emissao = DateTime.Now;

                context.Casos.Add(caso);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Casos/Edit/5
        public ActionResult Edit(long? id)
        {
            UpdateViewBag();
            return Get(id);
        }

        // POST: Casos/Edit/5
        [HttpPost]
        public ActionResult Edit(Caso caso)
        {
            caso.Emissao = DateTime.Now;

            if (ModelState.IsValid)
            {                
                context.Entry(caso).State = EntityState.Modified;
                context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(caso);            
        }

        // GET: Casos/Delete/5
        public ActionResult Delete(long? id)
        {
            return Get(id);
        }

        // POST: Casos/Delete/5
        [HttpPost]
        public ActionResult Delete(long id)
        {
            Caso caso = context.Casos.Find(id);

            context.Casos.Remove(caso);
            context.SaveChanges();

            TempData["DeleteMsg"] =

                "O seguinte caso de teste foi removido :" + caso.Nome;

            return RedirectToAction("Index");
        }

        private ActionResult Get(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Caso caso = 
                
                context
                    .Casos
                    .Where(c => c.Id == id).Include(p => p.Plano).First();

            if (caso == null) return HttpNotFound();

            return View(caso);
        }

        private void UpdateViewBag()
        {
            ViewBag.PlanoId = new SelectList
            (
                context.Planos.OrderBy(x => x.Nome), "Id", "Nome"
            );
        }

    }
}
