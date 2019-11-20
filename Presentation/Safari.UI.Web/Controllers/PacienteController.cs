using Safari.Entities;
using Safari.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Safari.UI.Web.Controllers
{
    public class PacienteController : Controller
    {
        // GET: Paciente
        public static Cliente clienteoriginal;
        public ActionResult Index(int id)
        {
            
            var biz = new PacienteProcess();
            var bizcliente = new ClienteProcess();
            var cliente = bizcliente.GetByID(id);
            var lista = biz.ListarTodos();
            var listafinal = new List<Paciente>();
            ViewBag.cliente = cliente;
            foreach (var item in lista)
            {
                if (item.ClienteId == id)
                {
                    listafinal.Add(item);
                }
            }
            clienteoriginal = cliente;

            return View(listafinal);
        }

        // GET: Paciente/Details/5
        public ActionResult Details(int id)
        {
            var biz = new PacienteProcess();
            var paciente = biz.GetByID(id);
            return View(paciente);
        }

        // GET: Paciente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Paciente/Create
        [HttpPost]
        public ActionResult Create(Paciente paciente)
        {
            try
            {
                var biz = new PacienteProcess();
                paciente.ClienteId = clienteoriginal.Id;
                var model = biz.Create(paciente);

                return RedirectToAction("Index", "Paciente", new { id = clienteoriginal.Id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Paciente/Edit/5
        public ActionResult Edit(int id)
        {
            var biz = new PacienteProcess();
            var paciente = biz.GetByID(id);
            return View(paciente);
        }

        // POST: Paciente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Paciente paciente)
        {
            var biz = new PacienteProcess();
            bool result = biz.Edit(paciente);

            if (result) { return RedirectToAction("Index", "Paciente", new { id = clienteoriginal.Id }); }
            else { return View(); }
        }

        // GET: Paciente/Delete/5
        public ActionResult Delete(int id)
        {
            var biz = new PacienteProcess();
            var paciente = biz.GetByID(id);
            return View(paciente);
        }

        // POST: Paciente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Paciente paciente)
        {
            var biz = new PacienteProcess();
            bool result = biz.Delete(paciente.Id);

            if (result) { return RedirectToAction("Index", "Paciente", new { id = clienteoriginal.Id }); }
            else { return View(); }
        }
    }
}
