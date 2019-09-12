using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Safari.UI.Web.Controllers
{
    public class MedicoController : Controller
    {
        // GET: Medico
        public ActionResult Index()
        {
            var biz = new MedicoComponent();
            var lista = biz.ListarTodos();
            return View(lista);
        }

        // GET: Medico/Details/5
        public ActionResult Details(int id)
        {
            var biz = new MedicoComponent();
            var Medico = biz.GetByID(id);
            return View(Medico);
        }

        // GET: Medico/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medico/Create
        [HttpPost]
        public ActionResult Create(Medico medico)
        {
            try
            {
                var biz = new MedicoComponent();
                var model = biz.Agregar(medico);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Medico/Edit/5
        public ActionResult Edit(int id)
        {
            var biz = new MedicoComponent();
            var Medico = biz.GetByID(id);
            return View(Medico);
        }

        // POST: Medico/Edit/5
        [HttpPost]
        public ActionResult Edit(Medico medico)
        {
            var biz = new MedicoComponent();
            bool result = biz.Edit(medico);

            if (result) { return RedirectToAction("Index"); }
            else { return View(); }
        }

        // GET: Medico/Delete/5
        public ActionResult Delete(int id)
        {
            var biz = new MedicoComponent();
            var Medico = biz.GetByID(id);
            return View(Medico);
        }

        // POST: Medico/Delete/5
        [HttpPost]
        public ActionResult Delete(Medico medico)
        {
            var biz = new MedicoComponent();
            bool result = biz.Delete(medico.Id);

            if (result) { return RedirectToAction("Index"); }
            else { return View(); }
        }
    }
}