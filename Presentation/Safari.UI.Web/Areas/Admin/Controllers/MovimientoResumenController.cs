using Safari.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Safari.UI.Web.Areas.Admin.Controllers
{
    public class MovimientoResumenController : Controller
    {
        // GET: Admin/MovimientoResumen
        decimal valortotal;
        public ActionResult Index()
        {
            MovimientoProcess biz = new MovimientoProcess();
            TipoMovimientoProcess biztipo = new TipoMovimientoProcess();
            var lista = biz.ListarTodos();

            foreach (var item in lista)
            {
                item.TipoMovimiento = biztipo.GetByID(item.TipoMovimientoId);

                if (item.TipoMovimiento.Multiplicador == 1)
                {
                    valortotal = valortotal + item.Valor;
                }

                if (item.TipoMovimiento.Multiplicador == 0)
                {
                    valortotal = valortotal - item.Valor;
                }

            }

            ViewBag.Monto = valortotal;

            return View();
        }

       
    }
}
