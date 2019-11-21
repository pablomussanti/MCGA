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
    public class TipoMovimientoProcess : ProcessComponent
    {
        ITipoMovimientoService TipoMovimientoServices = Framework.Common.ServiceFactory.Get<ITipoMovimientoService>();

        public List<TipoMovimiento> ListarTodos()
        {
            return TipoMovimientoServices.ListarTodos(); 
        }

        public TipoMovimiento Create(TipoMovimiento TipoMovimiento)
        {
            return TipoMovimientoServices.Create(TipoMovimiento);
        }

        public bool Edit(TipoMovimiento TipoMovimiento)
        {
            return TipoMovimientoServices.Edit(TipoMovimiento);
        }

        public TipoMovimiento GetByID(int ID)
        {
            return TipoMovimientoServices.GetByID(ID);
        }

        public bool Delete(int ID)
        {
            return TipoMovimientoServices.Delete(ID);
        }

    }
}
