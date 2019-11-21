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
    public class TipoServicioProcess : ProcessComponent
    {
        ITipoServicio TipoServicioServices = Framework.Common.ServiceFactory.Get<ITipoServicio>();

        public List<TipoServicio> ListarTodos()
        {
            return TipoServicioServices.ListarTodos();
        }

        public TipoServicio Create(TipoServicio TipoServicio)
        {
            return TipoServicioServices.Create(TipoServicio);
        }

        public bool Edit(TipoServicio TipoServicio)
        {
            return TipoServicioServices.Edit(TipoServicio);
        }

        public TipoServicio GetByID(int ID)
        {
            return TipoServicioServices.GetByID(ID);
        }

        public bool Delete(int ID)
        {
            return TipoServicioServices.Delete(ID);
        }

    }
}
