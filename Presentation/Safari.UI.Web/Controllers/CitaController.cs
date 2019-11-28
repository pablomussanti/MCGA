﻿using Safari.Entities;
using Safari.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Safari.UI.Web.Controllers
{
    [Authorize]
    public class CitaController : Controller
    {
        // GET: Cita
        int contador111;
        int contador112;
        public static string idusuario;
        MedicoProcess medicoprocess = new MedicoProcess();
        PacienteProcess pacienteprocess = new PacienteProcess();
        SalaProcess SalaProcess = new SalaProcess();
        TipoServicioProcess TipoServicioProcess = new TipoServicioProcess();

        public ActionResult Index()
        {
         
            
            idusuario = User.Identity.Name;
             
            var biz = new CitaProcess();
            var lista = biz.ListarTodosAuditor();
            var listafiltrada = new List<Cita>();
            foreach (var item in lista)
            {
                if (item.Deleted == false)
                {
                    item.Medico = medicoprocess.GetByID(item.MedicoId);
                    item.Paciente = pacienteprocess.GetByID(item.PacienteId);
                    item.Sala = SalaProcess.GetByID(item.SalaId);
                    item.TipoServicio = TipoServicioProcess.GetByID(item.TipoServicioId);
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
            ViewBag.TipoServicioId = new SelectList(TipoServicioProcess.ListarTodos(), "Id", "Nombre");
            ViewBag.SalaId = new SelectList(SalaProcess.ListarTodos(), "Id", "Nombre");
            ViewBag.MedicoId = new SelectList(medicoprocess.ListarTodos(), "Id", "Apellido");
            ViewBag.PacienteId = new SelectList(pacienteprocess.ListarTodos(), "Id", "Nombre");

            return View();
        }


        // POST: Cita/Create
        [HttpPost]
        public ActionResult Create(Cita Cita,string item5)
        {
            try
            {
                ViewBag.TipoServicioId = new SelectList(TipoServicioProcess.ListarTodos(), "Id", "Nombre");
                ViewBag.SalaId = new SelectList(SalaProcess.ListarTodos(), "Id", "Nombre");
                ViewBag.MedicoId = new SelectList(medicoprocess.ListarTodos(), "Id", "Nombre");
                ViewBag.PacienteId = new SelectList(pacienteprocess.ListarTodos(), "Id", "Nombre");
                var biz = new CitaProcess();
                Cita.CreatedBy = idusuario;
                Cita.Estado = item5;
                Cita.CreatedDate = DateTime.Now;
                var model = biz.Create(Cita);
                contador111 = 0;
                contador112 = 0;
                var bizmovimiento = new MovimientoProcess();
                var movimiento = new Movimiento();
                var bizmascotas = new PacienteProcess();

                foreach (var item in bizmascotas.ListarTodos())
                {
                    if (item.Id == Cita.PacienteId)
                    {
                        movimiento.ClienteId = item.ClienteId;
                    }
                }

                movimiento.Fecha = DateTime.Now;

                var biztipomovimiento = new TipoMovimientoProcess();
                if (biztipomovimiento.ListarTodos().Count == 0)
                {
                    var tipomovimiento = new TipoMovimiento();
                    tipomovimiento.Multiplicador = 1;
                    tipomovimiento.Nombre = "Cita Nueva";
                    biztipomovimiento.Create(tipomovimiento);
                }
                else
                {
                
                    foreach (var item in biztipomovimiento.ListarTodos())
                    {
                        if (item.Multiplicador == 1 && item.Nombre == "Cita Nueva")
                        {
                            movimiento.TipoMovimientoId = item.Id;
                        }
                        else
                        {
                            contador111 = contador111 + 1;
                        }
                    }
                }

                contador112 = biztipomovimiento.ListarTodos().Count;

                if (contador111 == contador112 && contador111 > 0 && contador112 > 0)
                {
                    var tipomovimiento = new TipoMovimiento();
                    tipomovimiento.Multiplicador = 1;
                    tipomovimiento.Nombre = "Cita Nueva";
                    biztipomovimiento.Create(tipomovimiento);
                }

                foreach (var item in biztipomovimiento.ListarTodos())
                {
                    if (item.Multiplicador == 1 && item.Nombre == "Cita Nueva")
                    {
                        movimiento.TipoMovimientoId = item.Id;
                    }
                }


                contador111 = 0;
                contador112 = 0;

                var bizprecio = new PrecioProcess();
                foreach (var item in bizprecio.ListarTodos())
                {
                    if (item.TipoServicioId == Cita.TipoServicioId)
                    {
                        if (item.FechaHasta > DateTime.Now && item.FechaDesde < DateTime.Now)
                        {
                            decimal deci;
                            deci = item.Valor;
                            movimiento.Valor = (decimal)deci;


                        }
                        else
                        {
                            contador111 = contador111 + 1;
                        }
                        contador112 = contador112 + 1;
                    }
                }

                if (contador111 == contador112 && contador111 > 0 && contador112 > 0)
                {
                    ViewBag.Advertencia1 = "No hay un precio establecido en ese periodo de tiempo";
                    throw new Exception();
                }

                bizmovimiento.Create(movimiento);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Cita/Edit/5
     
        public ActionResult Edit(int id)
        {
            var biz = new CitaProcess();
            var cita = biz.GetByID(id);
            ViewBag.TipoServicioId = new SelectList(TipoServicioProcess.ListarTodos(), "Id", "Nombre");
            ViewBag.SalaId = new SelectList(SalaProcess.ListarTodos(), "Id", "Nombre");
            ViewBag.MedicoId = new SelectList(medicoprocess.ListarTodos(), "Id", "Nombre");
            ViewBag.PacienteId = new SelectList(pacienteprocess.ListarTodos(), "Id", "Nombre");
            return View(cita);
        }

        // POST: Cita/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Cita cita,string item6)
        {
            ViewBag.TipoServicioId = new SelectList(TipoServicioProcess.ListarTodos(), "Id", "Nombre");
            ViewBag.SalaId = new SelectList(SalaProcess.ListarTodos(), "Id", "Nombre");
            ViewBag.MedicoId = new SelectList(medicoprocess.ListarTodos(), "Id", "Nombre");
            ViewBag.PacienteId = new SelectList(pacienteprocess.ListarTodos(), "Id", "Nombre");
            var biz = new CitaProcess();

            foreach (var item in biz.ListarTodosAuditor())
            {
                if (item.Id == cita.Id)
                {
                    cita.CreatedBy = item.CreatedBy;
                    cita.CreatedDate = item.CreatedDate;
                   
                }
            }
            cita.ChangedBy = idusuario;
            cita.Estado = item6;
            cita.ChangedDate = DateTime.Now;
            cita.DeletedDate = new DateTime(2000, 01, 01);

            bool result = biz.Edit(cita);

            if (result) { return RedirectToAction("Index"); }
            else { return View(); }
        }


        // GET: Cita/Delete/5
        public ActionResult Delete(int id)
        {
            var biz = new CitaProcess();
            var cita = biz.GetByID(id);
            return View(cita);
        }

        // POST: Cita/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Cita cita)
        {
            var biz = new CitaProcess();
            foreach (var item in biz.ListarTodosAuditor())
            {
                if (cita.Id == item.Id)
                {
                    cita = item;
                }
            }
            cita.ChangedBy = idusuario;
            cita.ChangedDate = DateTime.Now;
            cita.DeleteBy = idusuario;
            cita.DeletedDate = DateTime.Now;
            cita.Deleted = true;
            cita.Estado = "Cancelado";
            bool result = biz.Edit(cita);

            if (result) { return RedirectToAction("Index"); }
            else { return View(); }
        }

        public JsonResult Search(string term)
        {
            EspecieProcess ep = new EspecieProcess();
            var especies = ep.ListarTodos();
            var result = especies.Where(i => i.Nombre.Contains(term)).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);

        }


        public ActionResult Calendar(int id)
        {
            return View("Calendar");
        }

        //public JsonResult GetEvents()
        //{
        //    //using (Calendar dc = new Calendar())
        //    //{
        //    //    var biz = new CitaProcess();
        //    //    var lista = new List<Calendar>();

        //    //    foreach (var item in biz.ListarTodos())
        //    //    {
        //    //        var calendar = new Calendar();
        //    //        calendar.Description = item.Estado;
        //    //    }
        //    //    var lista =
        //    //    var events = dc.Events.ToList();
        //    //return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //    //}

        //}
    }
}
