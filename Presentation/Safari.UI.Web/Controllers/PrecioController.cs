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
    public class PrecioController : Controller
    {
        [Authorize]
        // GET: Precio
        public ActionResult Index()
        {
            var biz = new PrecioProcess();
            var lista = biz.ListarTodos();
            var tiposervicioprocess = new TipoServicioProcess();
            foreach (var item in lista)
            {

                item.TipoServicio = tiposervicioprocess.GetByID(item.TipoServicioId);


            }

            return View(lista);
        }
        [Authorize]
        // GET: Precio/Details/5
        public ActionResult Details(int id)
        {
            var biz = new PrecioProcess();
            var Precio = biz.GetByID(id);
            return View(Precio);
        }
        [Authorize]
        // GET: Precio/Create
        public ActionResult Create()
        {
            var biz = new TipoServicioProcess();
            var lista = biz.ListarTodos();
            ViewBag.TipoServicioId = new SelectList(lista, "Id", "Nombre");
            return View();
        }
        [Authorize]
        // POST: Precio/Create
        [HttpPost]
        public ActionResult Create(Precio Precio)
        {
            try
            {
                var biztp = new TipoServicioProcess();
                var lista2 = biztp.ListarTodos();
                ViewBag.TipoServicioId = new SelectList(lista2, "Id", "Nombre");
                int pasador = 0;
                var biz = new PrecioProcess();
                var model = new Precio();
                if (Precio.Valor > 0)
                {
                    if (Precio.FechaDesde < Precio.FechaHasta)
                    {

                        pasador = 1;

                    }
                    else
                    {
                        ViewBag.error2 = "Fechas incompatibles";
                        return View();
                    }

                }
                else
                {
                    ViewBag.error1 = "Monto invalido";
                    return View();
                }


                var lista = biz.ListarTodos();
                if (pasador == 1)
                {
                    pasador = 0;  
                    foreach (var item in lista)
                    {
                        if (item.TipoServicioId == Precio.TipoServicioId)
                        {
                            if (item.FechaHasta < Precio.FechaDesde)
                            {
                                pasador = pasador + 1;
                            }
                            else
                            {
                                ViewBag.error3 = "Ya existe un monto en esa fecha";
                                return View();
                            }
                        }

                    }

                }

                if (pasador == lista.Count)
                {
                    model = biz.Create(Precio);

                    return RedirectToAction("Index");
                }




                model = biz.Create(Precio);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [Authorize]
        // GET: Precio/Edit/5
        public ActionResult Edit(int id)
        {
            var biz = new PrecioProcess();
            var precio = biz.GetByID(id);
            return View(precio);
        }
        [Authorize]
        // POST: Precio/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Precio precio)
        {
            var biz = new PrecioProcess();
            bool result = biz.Edit(precio);

            if (result) { return RedirectToAction("Index"); }
            else { return View(); }
        }
        [Authorize]
        // GET: Precio/Delete/5
        public ActionResult Delete(int id)
        {
            var biz = new PrecioProcess();
            var precio = biz.GetByID(id);
            return View(precio);
        }
        [Authorize]
        // POST: Precio/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Precio precio, DateTime fechah,DateTime fechad)
        {
            var biz = new PrecioProcess();

            precio.Id = id;
            precio.FechaDesde = fechad;
            precio.FechaHasta = fechah;

            bool result = biz.Delete(precio);

            if (result) { return RedirectToAction("Index"); }
            else { return View(); }
        }
    }
}
