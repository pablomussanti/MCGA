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
    public class PrecioProcess : ProcessComponent
    {
        IPrecioService PrecioServices = Framework.Common.ServiceFactory.Get<IPrecioService>();

        public List<Precio> ListarTodos()
        {
            return PrecioServices.ListarTodos();
        }

        public Precio Create(Precio Precio)
        {
            return PrecioServices.Create(Precio);
        }

        public bool Edit(Precio Precio)
        {
            return PrecioServices.Edit(Precio);
        }

        public Precio GetByID(int ID)
        {
            return PrecioServices.GetByID(ID);
        }

        public bool Delete(Precio ID)
        {
            return PrecioServices.Delete(ID);
        }

    }
}
