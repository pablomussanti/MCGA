using Safari.Entities;
using Safari.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Safari.UI.Web.Controllers
{
    [Authorize]
    public class SalaController : Controller
    {
        [Authorize]
        // GET: Sala
        public ActionResult Index()
        {
            var biz = new SalaProcess();
            var lista = biz.ListarTodos();
            return View(lista);
        }

        // GET: Sala/Details/5
        public ActionResult Details(int id)
        {
            var biz = new SalaProcess();
            var lista = biz.GetByID(id);
            return View(lista);
        }

        // GET: Sala/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sala/Create
        [HttpPost]
        public ActionResult Create(Sala sala, string item3)
        {
            try
            {
                var biz = new SalaProcess();
                sala.TipoSala = item3;
                var model = biz.Create(sala);

                return RedirectToAction("Index");
            }
            catch(Exception sd)
            {
                return View(sd.Message);
            }
        }



        // GET: Sala/Edit/5
        public ActionResult Edit(int id)
        {
            var biz = new SalaProcess();
            var Sala = biz.GetByID(id);
            return View(Sala);
        }

        // POST: Sala/Edit/5
        [HttpPost]
        public ActionResult Edit(Sala sala, string item3)
        {
            var biz = new SalaProcess();
            sala.TipoSala = item3;
            bool result = biz.Edit(sala);

            if (result) { return RedirectToAction("Index"); }
            else { return View(); }
        }

        // GET: Sala/Delete/5
        public ActionResult Delete(int id)
        {
            var biz = new SalaProcess();
            var Sala = biz.GetByID(id);
            return View(Sala);
        }

        // POST: Sala/Delete/5
        [HttpPost]
        public ActionResult Delete(Sala sala)
        {
            var biz = new SalaProcess();
            var bizcita = new CitaProcess();

            foreach (var item in bizcita.ListarTodos())
            {
                if (item.SalaId == sala.Id)
                {
                    bizcita.Delete(item.Id);
                }
            }
            bool result = biz.Delete(sala.Id);

            if (result) { return RedirectToAction("Index"); }
            else { return View(); }
        }
    }
}
