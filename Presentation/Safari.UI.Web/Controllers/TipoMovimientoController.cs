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
    public class TipoMovimientoController : Controller
    {
        // GET: TipoMovimiento
        [Authorize]
        public ActionResult Index()
        {
            var biz = new TipoMovimientoProcess();
            var lista = biz.ListarTodos();

            return View(lista);
        }
        [Authorize]
        // GET: TipoMovimiento/Details/5
        public ActionResult Details(int id)
        {
            var biz = new TipoMovimientoProcess();
            var tipoMovimiento = biz.GetByID(id);
            return View(tipoMovimiento);
        }
        [Authorize]
        // GET: TipoMovimiento/Create
        public ActionResult Create()
        {
            return View();
        }
        [Authorize]
        // POST: TipoMovimiento/Create
        [HttpPost]
        public ActionResult Create(TipoMovimiento tipomovimiento)
        {
            try
            {
                var biz = new TipoMovimientoProcess();
                var model = biz.Create(tipomovimiento);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [Authorize]
        // GET: TipoMovimiento/Edit/5
        public ActionResult Edit(int id)
        {
            var biz = new TipoMovimientoProcess();
            var tipomovimiento = biz.GetByID(id);
            return View(tipomovimiento);
        }
        [Authorize]
        // POST: TipoMovimiento/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TipoMovimiento tipomovimiento)
        {
            var biz = new TipoMovimientoProcess();
            bool result = biz.Edit(tipomovimiento);

            if (result) { return RedirectToAction("Index"); }
            else { return View(); }
        }
        [Authorize]
        // GET: TipoMovimiento/Delete/5
        public ActionResult Delete(int id)
        {
            var biz = new TipoMovimientoProcess();
            var tipoMovimiento = biz.GetByID(id);
            return View(tipoMovimiento);
        }
        [Authorize]
        // POST: TipoMovimiento/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, TipoMovimiento tipomovimiento)
        {
            var biz = new TipoMovimientoProcess();
            var bizmovimiento = new MovimientoProcess();
            foreach (var item in bizmovimiento.ListarTodos())
            {
                if (item.TipoMovimientoId == tipomovimiento.Id)
                {
                    bizmovimiento.Delete(item.Id);
                }
            }

            bool result = biz.Delete(tipomovimiento.Id);

            if (result) { return RedirectToAction("Index"); }
            else { return View(); }
        }
    }
}
