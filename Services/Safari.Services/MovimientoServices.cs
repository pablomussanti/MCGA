using Safari.Entities;
using Safari.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Safari.Business;

namespace Safari.Services
{
    public class MovimientoServices : IMovimientoService
    {
        public List<Movimiento> ListarTodos()
        {
            MovimientoComponent MovimientoComponent = new MovimientoComponent();
            return MovimientoComponent.ListarTodos();
        }

        public Movimiento Create(Movimiento Movimiento)
        {
            MovimientoComponent MovimientoComponent = new MovimientoComponent();
            return MovimientoComponent.Create(Movimiento);
        }

        public bool Edit(Movimiento Movimiento)
        {
            MovimientoComponent MovimientoComponent = new MovimientoComponent();
            return MovimientoComponent.Edit(Movimiento);
        }

        public Movimiento GetByID(int ID)
        {
            MovimientoComponent MovimientoComponent = new MovimientoComponent();
            return MovimientoComponent.GetByID(ID);
        }

        public bool Delete(int ID)
        {
            MovimientoComponent MovimientoComponent = new MovimientoComponent();
            return MovimientoComponent.Delete(ID);
        }
    }
}
