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
            var lista = biz.ListarTodos();
            return View(lista);
        }

        // GET: Sala/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sala/Create
        [HttpPost]
        public ActionResult Create(Sala sala)
        {
            try
            {
                var biz = new SalaProcess();
                var model = biz.Create(sala);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
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
        public ActionResult Edit(Sala sala)
        {
            var biz = new SalaProcess();
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
            bool result = biz.Delete(sala.Id);

            if (result) { return RedirectToAction("Index"); }
            else { return View(); }
        }
    }
}
