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
    public class MovimientoController : Controller
    {
        ClienteProcess clienteprocess = new ClienteProcess();
        TipoMovimientoProcess tipomovimiento = new TipoMovimientoProcess();
        [Authorize]
        // GET: Movimiento
        public ActionResult Index()
        {
            var biz = new MovimientoProcess();
            var lista = biz.ListarTodos();

            foreach (var item in lista)
            {
                item.Cliente = clienteprocess.GetByID(item.ClienteId);
                item.TipoMovimiento = tipomovimiento.GetByID(item.TipoMovimientoId);
            }

            return View(lista);
        }
        [Authorize]
        // GET: Movimiento/Details/5
        public ActionResult Details(int id)
        {
            var biz = new MovimientoProcess();
            var movimiento = biz.GetByID(id);
            return View(movimiento);
        }
        [Authorize]
        // GET: Movimiento/Create
        public ActionResult Create()
        {

            ViewBag.TipoMovimientoId = new SelectList(tipomovimiento.ListarTodos(), "Id", "Nombre");
            ViewBag.ClienteId = new SelectList(clienteprocess.ListarTodos(), "Id", "Apellido");


            return View();
        }
        [Authorize]
        // POST: Movimiento/Create
        [HttpPost]
        public ActionResult Create(Movimiento movimiento)
        {
            try
            {

                ViewBag.TipoMovimientoId = new SelectList(tipomovimiento.ListarTodos(), "Id", "Nombre");
                ViewBag.ClienteId = new SelectList(clienteprocess.ListarTodos(), "Id", "Apellido");
                // TODO: Add insert logic here

                var biz = new MovimientoProcess();
                movimiento.Fecha = DateTime.Now;
                var model = biz.Create(movimiento);

                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }
        [Authorize]
        // GET: Movimiento/Edit/5
        public ActionResult Edit(int id)
        {

            ViewBag.TipoMovimientoId = new SelectList(tipomovimiento.ListarTodos(), "Id", "Nombre");
            ViewBag.ClienteId = new SelectList(clienteprocess.ListarTodos(), "Id", "Apellido");
            var biz = new MovimientoProcess();
            var movimiento = biz.GetByID(id);
            return View(movimiento);
        }
        [Authorize]
        // POST: Movimiento/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Movimiento movimiento)
        {
         


            ViewBag.TipoMovimientoId = new SelectList(tipomovimiento.ListarTodos(), "Id", "Nombre");
            ViewBag.ClienteId = new SelectList(clienteprocess.ListarTodos(), "Id", "Apellido");
            var biz = new MovimientoProcess();
            bool result = biz.Edit(movimiento);

            if (result) { return RedirectToAction("Index"); }
            else { return View(); }

        }
        [Authorize]
        // GET: Movimiento/Delete/5
        public ActionResult Delete(int id)
        {
            var biz = new MovimientoProcess();
            var movimiento = biz.GetByID(id);
            return View(movimiento);
        }
        [Authorize]
        // POST: Movimiento/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Movimiento Movimiento)
        {
            var biz = new MovimientoProcess();

            bool result = biz.Delete(Movimiento.Id);

            if (result) { return RedirectToAction("Index"); }
            else { return View(); }
        }
    }
}
