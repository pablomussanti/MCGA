using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Safari.UI.Process;

namespace Safari.UI.Web.Controllers
{
    [Authorize]
    public class MedicoController : Controller
    {

        [Authorize]
        // GET: Medico
        public ActionResult Index()
        {
            var biz = new MedicoProcess();
            var lista = biz.ListarTodos();
            return View(lista);
        }


        [Authorize]
        // GET: Medico/Details/5
        public ActionResult Details(int id)
        {
            var biz = new MedicoProcess();
            var Medico = biz.GetByID(id);
            return View(Medico);
        }

        [Authorize]

        // GET: Medico/Create
        public ActionResult Create()
        {
            return View();
        }
        [Authorize]
        // POST: Medico/Create
        [HttpPost]
        public ActionResult Create(Medico medico, string item2)
        {
            try
            {
                var biz = new MedicoProcess();
                medico.TipoMatricula = item2;
                var model = biz.Create(medico);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }
        [Authorize]
        // GET: Medico/Edit/5
        public ActionResult Edit(int id)
        {
            var biz = new MedicoProcess();
            var Medico = biz.GetByID(id);
            return View(Medico);
        }
        [Authorize]
        // POST: Medico/Edit/5
        [HttpPost]
        public ActionResult Edit(Medico medico,string item2)
        {
            var biz = new MedicoProcess();
            medico.TipoMatricula = item2;
            bool result = biz.Edit(medico);

            if (result) { return RedirectToAction("Index"); }
            else { return View(); }
        }
        [Authorize]
        // GET: Medico/Delete/5
        public ActionResult Delete(int id)
        {
            var biz = new MedicoProcess();
            var Medico = biz.GetByID(id);
            return View(Medico);
        }
        [Authorize]
        // POST: Medico/Delete/5
        [HttpPost]
        public ActionResult Delete(Medico medico)
        {
            var biz = new MedicoProcess();
            var bizcita = new CitaProcess();
            foreach (var item in bizcita.ListarTodos())
            {
                if (item.MedicoId == medico.Id)
                {
                    bizcita.Delete(item.Id);
                }
            }


            bool result = biz.Delete(medico.Id);

            if (result) { return RedirectToAction("Index"); }
            else { return View(); }
        }
    }
}