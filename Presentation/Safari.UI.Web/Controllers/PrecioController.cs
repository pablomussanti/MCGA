using Safari.Entities;
using Safari.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Safari.UI.Web.Controllers
{
    public class PrecioController : Controller
    {
        // GET: Precio
        public ActionResult Index()
        {
            var biz = new PrecioProcess();
            var lista = biz.ListarTodos();
            return View(lista);
        }

        // GET: Precio/Details/5
        public ActionResult Details(int id)
        {
            var biz = new PrecioProcess();
            var Precio = biz.GetByID(id);
            return View(Precio);
        }

        // GET: Precio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Precio/Create
        [HttpPost]
        public ActionResult Create(Precio Precio)
        {
            try
            {
                var biz = new PrecioProcess();
                var model = biz.Create(Precio);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Precio/Edit/5
        public ActionResult Edit(int id)
        {
            var biz = new PrecioProcess();
            var precio = biz.GetByID(id);
            return View(precio);
        }

        // POST: Precio/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Precio precio)
        {
            var biz = new PrecioProcess();
            bool result = biz.Edit(precio);

            if (result) { return RedirectToAction("Index"); }
            else { return View(); }
        }

        // GET: Precio/Delete/5
        public ActionResult Delete(int id)
        {
            var biz = new PrecioProcess();
            var precio = biz.GetByID(id);
            return View(precio);
        }

        // POST: Precio/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Precio precio)
        {
            var biz = new PrecioProcess();
            bool result = biz.Delete(precio.TipoServicioId);

            if (result) { return RedirectToAction("Index"); }
            else { return View(); }
        }
    }
}
