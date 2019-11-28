using Safari.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Safari.UI.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CitaAuditoriaController : Controller
    {
        // GET: Admin/CitaAuditoria
        MedicoProcess medicoprocess = new MedicoProcess();
        PacienteProcess pacienteprocess = new PacienteProcess();
        SalaProcess SalaProcess = new SalaProcess();
        TipoServicioProcess TipoServicioProcess = new TipoServicioProcess();

        public ActionResult Index()
        {
            var biz = new CitaProcess();
            var lista = biz.ListarTodosAuditor();
            foreach (var item in lista)
            {
               
                    item.Medico = medicoprocess.GetByID(item.MedicoId);
                    item.Paciente = pacienteprocess.GetByID(item.PacienteId);
                    item.Sala = SalaProcess.GetByID(item.SalaId);
                    item.TipoServicio = TipoServicioProcess.GetByID(item.TipoServicioId);
                
                
            }
            return View(lista);
        }

        // GET: Admin/CitaAuditoria/Details/5
      
    }
}
