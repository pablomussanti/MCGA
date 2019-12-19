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
    public class PacienteController : Controller
    {
        // GET: Paciente
       
        public static Cliente clienteoriginal;
        [Authorize]
        public ActionResult Index(int id)
        {
            
            var biz = new PacienteProcess();
            var bizcliente = new ClienteProcess();
            var bizespecie = new EspecieProcess();
            var cliente = bizcliente.GetByID(id);
            var lista = biz.ListarTodos();
            var listafinal = new List<Paciente>();
            ViewBag.cliente = cliente;
            foreach (var item in lista)
            {
                if (item.ClienteId == id)
                {
                    item.Especie = bizespecie.GetByID(item.EspecieId);
                    item.Cliente = bizcliente.GetByID(item.ClienteId);
                    listafinal.Add(item);
                }
            }
            clienteoriginal = cliente;

            return View(listafinal);
        }
        [Authorize]
        // GET: Paciente/Details/5
        public ActionResult Details(int id)
        {
            var biz = new PacienteProcess();
            var paciente = biz.GetByID(id);
            return View(paciente);
        }
        [Authorize]
        // GET: Paciente/Create
        public ActionResult Create()
        {
            return View();
        }
        [Authorize]
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
        [Authorize]
        // GET: Paciente/Edit/5
        public ActionResult Edit(int id)
        {
            var biz = new PacienteProcess();
            var paciente = biz.GetByID(id);
            return View(paciente);
        }
        [Authorize]
        // POST: Paciente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Paciente paciente)
        {
            var biz = new PacienteProcess();
            paciente.ClienteId = clienteoriginal.Id;
            bool result = biz.Edit(paciente);

            if (result) { return RedirectToAction("Index", "Paciente", new { id = clienteoriginal.Id }); }
            else { return View(); }
        }
        [Authorize]
        // GET: Paciente/Delete/5
        public ActionResult Delete(int id)
        {
            var biz = new PacienteProcess();
            var paciente = biz.GetByID(id);
            return View(paciente);
        }
        [Authorize]
        // POST: Paciente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Paciente paciente)
        {
            var biz = new PacienteProcess();
            var bizcita = new CitaProcess();

            foreach (var item in bizcita.ListarTodos())
            {
                if (item.PacienteId == paciente.Id)
                {
                    bizcita.Delete(item.Id);
                }
            }


            bool result = biz.Delete(paciente.Id);

            

            if (result) { return RedirectToAction("Index", "Paciente", new { id = clienteoriginal.Id }); }
            else { return View(); }
        }


        public JsonResult Search(string term)
        {
            EspecieProcess ep = new EspecieProcess();
            var especies = ep.ListarTodos();
            var result = especies.Where(i => i.Nombre.Contains(term)).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);

        }
    }
}
