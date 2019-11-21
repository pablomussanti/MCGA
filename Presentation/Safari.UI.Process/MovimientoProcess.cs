using Safari.Entities;
using Safari.Services;
using Safari.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.UI.Process
{
    public class MovimientoProcess : ProcessComponent
    {
        IMovimientoService MovimientoServices = Framework.Common.ServiceFactory.Get<IMovimientoService>();

        public List<Movimiento> ListarTodos()
        {
            return MovimientoServices.ListarTodos();
        }

        public Movimiento Create(Movimiento Movimiento)
        {
            return MovimientoServices.Create(Movimiento);
        }

        public bool Edit(Movimiento Movimiento)
        {
            return MovimientoServices.Edit(Movimiento);
        }

        public Movimiento GetByID(int ID)
        {
            return MovimientoServices.GetByID(ID);
        }

        public bool Delete(int ID)
        {
            return MovimientoServices.Delete(ID);
        }

    }
}
