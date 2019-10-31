using Safari.Business;
using Safari.Entities;
using Safari.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services
{
    public class TipoServicioServices : ITipoServicio
    {
        public List<TipoServicio> ListarTodos()
        {
            TipoServicioComponent TipoServicioComponent = new TipoServicioComponent();
            return TipoServicioComponent.ListarTodos();
        }

        public TipoServicio Create(TipoServicio TipoServicio)
        {
            TipoServicioComponent TipoServicioComponent = new TipoServicioComponent();
            return TipoServicioComponent.Create(TipoServicio);
        }

        public bool Edit(TipoServicio TipoServicio)
        {
            TipoServicioComponent TipoServicioComponent = new TipoServicioComponent();
            return TipoServicioComponent.Edit(TipoServicio);
        }

        public TipoServicio GetByID(int ID)
        {
            TipoServicioComponent TipoServicioComponent = new TipoServicioComponent();
            return TipoServicioComponent.GetByID(ID);
        }

        public bool Delete(int ID)
        {
            TipoServicioComponent TipoServicioComponent = new TipoServicioComponent();
            return TipoServicioComponent.Delete(ID);
        }
    }
}
