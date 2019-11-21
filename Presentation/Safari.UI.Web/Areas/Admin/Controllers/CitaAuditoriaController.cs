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
        public ActionResult Index()
        {
            var biz = new CitaProcess();
            var lista = biz.ListarTodos();
            return View(lista);
        }

        // GET: Admin/CitaAuditoria/Details/5
      
    }
}
