﻿using Safari.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Safari.UI.Web.Controllers
{
    public class EspecieController : Controller
    {
        // GET: Especie

        public ActionResult Index()
        {
            var biz = new EspecieComponent();
            var lista = biz.ListarTodos();
            return View(lista);
        }

        // GET: Especie/Details/5
        public ActionResult Details(int id)
        {
            var biz = new EspecieComponent();
            var Especie = biz.GetByID(id);
            return View(Especie);
        }

        // GET: Especie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Especie/Create
        [HttpPost]
        public ActionResult Create(Especie especie)
        {
            try
            {
                var biz = new EspecieComponent();
                var model = biz.Agregar(especie);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Especie/Edit/5
        public ActionResult Edit(int id)
        {
            var biz = new EspecieComponent();
            var Especie = biz.GetByID(id);
            return View(Especie);
        }

        // POST: Especie/Edit/5
        [HttpPost]
        public ActionResult Edit(Especie especie)
        {
            var biz = new EspecieComponent();
            bool result = biz.Edit(especie);

            if (result) { return RedirectToAction("Index"); }
            else { return View(); }

        }

        // GET: Especie/Delete/5
        public ActionResult Delete(int id)
        {
            var biz = new EspecieComponent();
            var Especie = biz.GetByID(id);
            return View(Especie);
        }

        // POST: Especie/Delete/5
        [HttpPost]
        public ActionResult Delete(Especie especie)
        {
            var biz = new EspecieComponent();
            bool result = biz.Delete(especie.Id);

            if (result) { return RedirectToAction("Index"); }
            else { return View(); }
        }




        public ActionResult ExportarEspeciesCSV()
        {
            var biz = new EspecieComponent();
            var especies = biz.ListarTodos();


            var stream = new MemoryStream();
            var streamWriter = new StreamWriter(stream, Encoding.Default);

            foreach (var item in especies)
            {
                var properties = typeof(Especie).GetProperties();
                foreach (var prop in properties)
                {
                    streamWriter.Write(GetValue(item, prop.Name));
                    streamWriter.Write(", ");
                }
                streamWriter.WriteLine();
            }

            streamWriter.Flush();
            stream.Position = 0;

            return File(stream, "text/csv");
        }

        private static string GetValue(object item, string propName)
        {
            return item.GetType().GetProperty(propName).GetValue(item, null).ToString() ?? "";
        }

        public void ExportarEspeciesXML()
        {
            var biz = new EspecieComponent();
            var especies = biz.ListarTodos();

            var serializer = new XmlSerializer(especies.GetType());
            Response.ContentType = "text/xml";
            serializer.Serialize(Response.Output, especies);
        }

    }

}