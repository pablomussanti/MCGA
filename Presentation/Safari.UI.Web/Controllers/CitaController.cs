using Safari.Entities;
using Safari.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Safari.UI.Web.Controllers
{
    public class CitaController : Controller
    {
        // GET: Cita
        public static int idusuario;
        public ActionResult Index()
        {
         

            idusuario = (int)Membership.GetUser().ProviderUserKey;

            var biz = new CitaProcess();
            var lista = biz.ListarTodos();
            var listafiltrada = new List<Cita>();
            foreach (var item in lista)
            {
                if (item.Deleted == false)
                {
                    listafiltrada.Add(item);
                }
            }

            return View(listafiltrada);
        }

        // GET: Cita/Details/5
        public ActionResult Details(int id)
        {
            var biz = new CitaProcess();
            var Cita = biz.GetByID(id);
            return View(Cita);
        }

        // GET: Cita/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cita/Create
        [HttpPost]
        public ActionResult Create(Cita Cita)
        {
            try
            {
                var biz = new CitaProcess();
                Cita.CreatedBy = idusuario;
                Cita.CreatedDate = DateTime.Now;
                var model = biz.Create(Cita);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cita/Edit/5
        public ActionResult Edit(int id)
        {
            var biz = new CitaProcess();
            var cita = biz.GetByID(id);
            return View(cita);
        }

        // POST: Cita/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Cita cita)
        {
            var biz = new CitaProcess();
            cita.ChangedBy = idusuario;
            cita.ChangedDate = DateTime.Now;
            bool result = biz.Edit(cita);

            if (result) { return RedirectToAction("Index"); }
            else { return View(); }
        }

        // GET: Cita/Delete/5
        public ActionResult Delete(int id)
        {
            var biz = new PrecioProcess();
            var precio = biz.GetByID(id);
            return View(precio);
        }   

        // POST: Cita/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Cita cita)
        {
            var biz = new CitaProcess();
            cita.DeleteBy = idusuario;
            cita.DeletedDate = DateTime.Now;
            cita.Deleted = true;

            bool result = biz.Edit(cita);

            if (result) { return RedirectToAction("Index"); }
            else { return View(); }
        }
    }
}
