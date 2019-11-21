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
    public class PrecioServices : IPrecioService
    {
        public List<Precio> ListarTodos()
        {
            PrecioComponent PrecioComponent = new PrecioComponent();
            return PrecioComponent.ListarTodos();
        }

        public Precio Create(Precio Precio)
        {
            PrecioComponent PrecioComponent = new PrecioComponent();
            return PrecioComponent.Agregar(Precio);
        }

        public bool Edit(Precio Precio)
        {
            PrecioComponent PrecioComponent = new PrecioComponent();
            return PrecioComponent.Edit(Precio);
        }

        public Precio GetByID(int ID)
        {
            PrecioComponent PrecioComponent = new PrecioComponent();
            return PrecioComponent.GetByID(ID);
        }

        public bool Delete(int ID)
        {
            PrecioComponent PrecioComponent = new PrecioComponent();
            return PrecioComponent.Delete(ID);
        }
    }
}
