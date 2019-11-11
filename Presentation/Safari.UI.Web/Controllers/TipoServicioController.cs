using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Safari.UI.Web.Controllers
{
    public class TipoServicioController : Controller
    {
        // GET: TipoServicio
        public ActionResult Index()
        {
            return View();
        }

        // GET: TipoServicio/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TipoServicio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoServicio/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoServicio/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TipoServicio/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoServicio/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TipoServicio/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
