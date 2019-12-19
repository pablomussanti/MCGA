using Safari.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;
using Safari.UI.Process;

namespace Safari.UI.Web.Controllers
{
    [Authorize]
    public class EspecieController : Controller
    {
        // GET: Especie
        [Authorize]
        public ActionResult Index()
        {
            var biz = new EspecieProcess();
            var lista = biz.ListarTodos();
            return View(lista);
        }
        [Authorize]
        // GET: Especie/Details/5
        public ActionResult Details(int id)
        {
            var biz = new EspecieProcess();
            var Especie = biz.GetByID(id);
            return View(Especie);
        }
        [Authorize]
        // GET: Especie/Create
        public ActionResult Create()
        {
            return View();
        }
        [Authorize]
        // POST: Especie/Create
        [HttpPost]
        public ActionResult Create(Especie especie)
        {
            try
            {
                var biz = new EspecieProcess();
                var model = biz.Create(especie);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [Authorize]
        // GET: Especie/Edit/5
        public ActionResult Edit(int id)
        {
            var biz = new EspecieProcess();
            var Especie = biz.GetByID(id);
            return View(Especie);
        }
        [Authorize]
        // POST: Especie/Edit/5
        [HttpPost]
        public ActionResult Edit(Especie especie)
        {
            var biz = new EspecieProcess();
            bool result = biz.Edit(especie);

            if (result) { return RedirectToAction("Index"); }
            else { return View(); }

        }
        [Authorize]
        // GET: Especie/Delete/5
        public ActionResult Delete(int id)
        {
            var biz = new EspecieProcess();
            var Especie = biz.GetByID(id);
            return View(Especie);
        }
        [Authorize]
        // POST: Especie/Delete/5
        [HttpPost]
        public ActionResult Delete(Especie especie)
        {
            var biz = new EspecieProcess();
            var bizpaciente = new PacienteProcess();

            foreach (var item in bizpaciente.ListarTodos())
            {
                if (item.EspecieId == especie.Id)
                {
                    bizpaciente.Delete(item.Id);
                }
            }

            bool result = biz.Delete(especie.Id);

            if (result) { return RedirectToAction("Index"); }
            else { return View(); }
        }




        public ActionResult ExportarEspeciesCSV()
        {
            var biz = new EspecieProcess();
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
            var biz = new EspecieProcess();
            var especies = biz.ListarTodos();

            var serializer = new XmlSerializer(especies.GetType());
            Response.ContentType = "text/xml";
            serializer.Serialize(Response.Output, especies);
        }

    }

}
