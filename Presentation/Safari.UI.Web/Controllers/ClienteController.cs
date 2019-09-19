using Safari.Entities;
using Safari.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Safari.UI.Web.Controllers
{
    public class ClienteController : Controller
    {
        [Authorize]
        // GET: Cliente
        public ActionResult Index()
        {
            var biz = new ClienteProcess();
            var lista = biz.ListarTodos();
            return View(lista);
        }
        [Authorize]
        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            var biz = new ClienteProcess();
            var Cliente = biz.GetByID(id);
            return View(Cliente);
        }
        [Authorize]
        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }
        [Authorize]
        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            try
            {
                var biz = new ClienteProcess();
                var model = biz.Create(cliente);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [Authorize]
        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            var biz = new ClienteProcess();
            var Cliente = biz.GetByID(id);
            return View(Cliente);
        }
        [Authorize]
        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(Cliente cliente)
        {
            var biz = new ClienteProcess();
            bool result = biz.Edit(cliente);

            if (result) { return RedirectToAction("Index"); }
            else { return View(); }
        }
        [Authorize]
        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            var biz = new ClienteProcess();
            var Cliente = biz.GetByID(id);
            return View(Cliente);
        }
        [Authorize]
        // POST: Cliente/Delete/5
        [HttpPost]
        public ActionResult Delete(Cliente cliente)
        {
            var biz = new ClienteProcess();
            bool result = biz.Delete(cliente.Id);

            if (result) { return RedirectToAction("Index"); }
            else { return View(); }
        }
    }
}
