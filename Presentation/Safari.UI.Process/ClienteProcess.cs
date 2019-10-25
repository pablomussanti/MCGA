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
    public class ClienteProcess
    {
        IClienteService ClienteServices = Framework.Common.ServiceFactory.Get<IClienteService>();

        public List<Cliente> ListarTodos()
        {
            return ClienteServices.ListarTodos();
        }

        public Cliente Create(Cliente cliente)
        {
            return ClienteServices.Create(cliente);
        }

        public bool Edit(Cliente cliente)
        {
            return ClienteServices.Edit(cliente);
        }

        public Cliente GetByID(int ID)
        {
            return ClienteServices.GetByID(ID);
        }

        public bool Delete(int ID)
        {
            return ClienteServices.Delete(ID);
        }

    }
}
