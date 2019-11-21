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
    public class TipoMovimientoServices : ITipoMovimientoService
    {
        public List<TipoMovimiento> ListarTodos()
        {
            TipoMovimientoComponent TipoMovimientoComponent = new TipoMovimientoComponent();
            return TipoMovimientoComponent.ListarTodos();
        }

        public TipoMovimiento Create(TipoMovimiento TipoMovimiento)
        {
            TipoMovimientoComponent TipoMovimientoComponent = new TipoMovimientoComponent();
            return TipoMovimientoComponent.Create(TipoMovimiento);
        }

        public bool Edit(TipoMovimiento TipoMovimiento)
        {
            TipoMovimientoComponent TipoMovimientoComponent = new TipoMovimientoComponent();
            return TipoMovimientoComponent.Edit(TipoMovimiento);
        }

        public TipoMovimiento GetByID(int ID)
        {
            TipoMovimientoComponent TipoMovimientoComponent = new TipoMovimientoComponent();
            return TipoMovimientoComponent.GetByID(ID);
        }

        public bool Delete(int ID)
        {
            TipoMovimientoComponent TipoMovimientoComponent = new TipoMovimientoComponent();
            return TipoMovimientoComponent.Delete(ID);
        }
    }
}
