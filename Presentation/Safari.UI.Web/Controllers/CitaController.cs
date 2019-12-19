using PagedList;
using PagedList.Mvc;
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


        [Authorize]
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
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


            ViewBag.CurrentSort = sortOrder;

            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";


            if (searchString != null)
                page = 1;
            else
                searchString = currentFilter;


            ViewBag.CurrentFilter = searchString;

            IEnumerable<Cita> citaelegida = listafiltrada;

  

            if (!string.IsNullOrEmpty(searchString))
                citaelegida = citaelegida.Where(s => s.Paciente.Nombre.Contains(searchString));

            switch (sortOrder)
            {
                case "name_desc":
                    citaelegida = citaelegida.OrderByDescending(s => s.Paciente.Nombre);
                    break;
                case "Date":
                    citaelegida = citaelegida.OrderBy(s => s.Fecha);
                    break;
                default:
                    citaelegida = citaelegida.OrderBy(s => s.Paciente.Nombre);
                    break;
            }


            //return View(clientes.ToList());
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(citaelegida.ToPagedList(pageNumber, pageSize));



            //return View(listafiltrada);
        }

        [Authorize]
        // GET: Cita/Details/5
        public ActionResult Details(int id)
        {
            var biz = new CitaProcess();
            var Cita = biz.GetByID(id);
            return View(Cita);
        }

        [Authorize]
        // GET: Cita/Create
        public ActionResult Create()
        {
            ViewBag.TipoServicioId = new SelectList(TipoServicioProcess.ListarTodos(), "Id", "Nombre");
            ViewBag.SalaId = new SelectList(SalaProcess.ListarTodos(), "Id", "Nombre");
            ViewBag.MedicoId = new SelectList(medicoprocess.ListarTodos(), "Id", "Apellido");
            ViewBag.PacienteId = new SelectList(pacienteprocess.ListarTodos(), "Id", "Nombre");

            return View();
        }


        [Authorize]
        // POST: Cita/Create
        [HttpPost]
        public ActionResult Create(Cita Cita,string item5,int hora)
        {
            try
            {
                ViewBag.TipoServicioId = new SelectList(TipoServicioProcess.ListarTodos(), "Id", "Nombre");
                ViewBag.SalaId = new SelectList(SalaProcess.ListarTodos(), "Id", "Nombre");
                ViewBag.MedicoId = new SelectList(medicoprocess.ListarTodos(), "Id", "Nombre");
                ViewBag.PacienteId = new SelectList(pacienteprocess.ListarTodos(), "Id", "Nombre");
                if (hora >= 0 &&  hora <= 24 )
                {

                }
                else
                {
                    ViewBag.Advertencia3 = "Hora invalida";
                    throw new Exception();
                }
  
                var biz = new CitaProcess();
                Cita.CreatedBy = idusuario;
                Cita.Estado = item5;
                Cita.CreatedDate = DateTime.Now;
                DateTime fechareal = new DateTime(Cita.Fecha.Year, Cita.Fecha.Month, Cita.Fecha.Day, hora, Cita.Fecha.Minute, Cita.Fecha.Second);
                Cita.Fecha = fechareal;
                int contadorfecha = 0;

                foreach (var item in biz.ListarTodos())
                {
                    if (item.Fecha == Cita.Fecha && item.Estado != "Cancelado" && item.MedicoId == Cita.MedicoId)
                    {
                        contadorfecha = 1;
                    }

                }

                if (contadorfecha == 0)
                {
                    var model = biz.Create(Cita);
                    Cita = model;
                }
                else
                {
                    ViewBag.Advertencia2 = "Ya existe turno en esa fecha";
                    throw new Exception();
                }
               


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
                        if (item.FechaHasta >= DateTime.Now && item.FechaDesde <= DateTime.Now)
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

                    biz.Delete(Cita.Id);
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

        [Authorize]
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

        [Authorize]

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

        [Authorize]

        // GET: Cita/Delete/5
        public ActionResult Delete(int id)
        {
            var biz = new CitaProcess();
            var cita = biz.GetByID(id);
            return View(cita);
        }

        [Authorize]
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


            var bizmovimiento = new MovimientoProcess();
            var movimiento = new Movimiento();
            var bizmascotas = new PacienteProcess();

            foreach (var item in bizmascotas.ListarTodos())
            {
                if (item.Id == cita.PacienteId)
                {
                    movimiento.ClienteId = item.ClienteId;
                }
            }

            movimiento.Fecha = DateTime.Now;

            var biztipomovimiento = new TipoMovimientoProcess();
            if (biztipomovimiento.ListarTodos().Count == 0)
            {
                var tipomovimiento = new TipoMovimiento();
                tipomovimiento.Multiplicador = 0;
                tipomovimiento.Nombre = "Cancelacion de Cita";
                biztipomovimiento.Create(tipomovimiento);
            }
            else
            {

                foreach (var item in biztipomovimiento.ListarTodos())
                {
                    if (item.Multiplicador == 0 && item.Nombre == "Cancelacion de Cita")
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
                tipomovimiento.Multiplicador = 0;
                tipomovimiento.Nombre = "Cancelacion de Cita";
                biztipomovimiento.Create(tipomovimiento);
            }

            foreach (var item in biztipomovimiento.ListarTodos())
            {
                if (item.Multiplicador == 0 && item.Nombre == "Cancelacion de Cita")
                {
                    movimiento.TipoMovimientoId = item.Id;
                }
            }


            contador111 = 0;
            contador112 = 0;

            var bizprecio = new PrecioProcess();
            foreach (var item in bizprecio.ListarTodos())
            {
                if (item.TipoServicioId == cita.TipoServicioId)
                {
                    if (item.FechaHasta >= DateTime.Now && item.FechaDesde <= DateTime.Now)
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


            bizmovimiento.Create(movimiento);

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


        public ActionResult Calendar()
        {
            return View("Calendar");
        }

        public JsonResult GetEvents()
        {
            using (Calendar dc = new Calendar())
            {
                var biz = new CitaProcess();
                var lista = new List<Calendar>();

                foreach (var item in biz.ListarTodos())
                {
                    if (item.Deleted == false)
                    {
                        if (item.Estado == "Cancelado")
                        {

                        }
                        else
                        {

                            var calendar = new Calendar();
                            calendar.Description = item.Estado;

                            calendar.Start = item.Fecha;
                            item.Fecha = new DateTime(item.Fecha.Year, item.Fecha.Month, item.Fecha.Day, item.Fecha.Hour + 1, item.Fecha.Minute, item.Fecha.Second);
                            calendar.End = item.Fecha;
                            item.Paciente = pacienteprocess.GetByID(item.PacienteId);
                            item.Sala = SalaProcess.GetByID(item.SalaId);
                            item.TipoServicio = TipoServicioProcess.GetByID(item.TipoServicioId);
                            item.Medico = medicoprocess.GetByID(item.MedicoId);
                            calendar.Subject = string.Format("El paciente {0} tiene turno con {1} en la sala {2} para {3}", item.Paciente.Nombre, item.Medico.Apellido, item.Sala.Nombre, item.TipoServicio.Nombre);

                            lista.Add(calendar);


                        }
                        
                       
                    }
                    
                }
                
                var events = lista;
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

        }
    }
}
