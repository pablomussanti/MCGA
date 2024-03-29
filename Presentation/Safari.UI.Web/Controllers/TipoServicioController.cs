﻿using Safari.Entities;
using Safari.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Safari.UI.Web.Controllers
{
    [Authorize]
    public class TipoServicioController : Controller
    {
        [Authorize]
        // GET: TipoServicio
        public ActionResult Index()
        {
            var biz = new TipoServicioProcess();
            var lista = biz.ListarTodos();

            return View(lista);
        }
        [Authorize]
        // GET: TipoServicio/Details/5
        public ActionResult Details(int id)
        {
            var biz = new TipoServicioProcess();
            var tiposervicio = biz.GetByID(id);
            return View(tiposervicio);
        }
        [Authorize]
        // GET: TipoServicio/Create
        public ActionResult Create()
        {
            return View();
        }
        [Authorize]
        // POST: TipoServicio/Create
        [HttpPost]
        public ActionResult Create(TipoServicio tiposervicio)
        {
            try
            {
                var biz = new TipoServicioProcess();
                var model = biz.Create(tiposervicio);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [Authorize]
        // GET: TipoServicio/Edit/5
        public ActionResult Edit(int id)
        {
            var biz = new TipoServicioProcess();
            var tiposervicio = biz.GetByID(id);
            return View(tiposervicio);
        }
        [Authorize]
        // POST: TipoServicio/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TipoServicio tiposervicio)
        {
            var biz = new TipoServicioProcess();
            bool result = biz.Edit(tiposervicio);

            if (result) { return RedirectToAction("Index"); }
            else { return View(); }
        }
        [Authorize]
        // GET: TipoServicio/Delete/5
        public ActionResult Delete(int id)
        {
            var biz = new TipoServicioProcess();
            var tiposervicio = biz.GetByID(id);
            return View(tiposervicio);
        }
        [Authorize]
        // POST: TipoServicio/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, TipoServicio tiposervicio)
        {
            var biz = new TipoServicioProcess();
            var bizprecio = new PrecioProcess();
            var bizcita = new CitaProcess();
            foreach (var item in bizcita.ListarTodos())
            {
                if (item.TipoServicioId == tiposervicio.Id)
                {
                    bizcita.Delete(item.Id);
                }
            }

            foreach (var item in bizprecio.ListarTodos())
            {
                if (item.TipoServicioId == tiposervicio.Id)
                {
                    item.Id = item.TipoServicioId;
                    bizprecio.Delete(item);
                }
            }

            bool result = biz.Delete(tiposervicio.Id);

            if (result) { return RedirectToAction("Index"); }
            else { return View(); }
        }
    }
}
