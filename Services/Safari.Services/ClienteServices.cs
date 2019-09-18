using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Safari.Business;
using Safari.Services.Contracts;

namespace Safari.Services
{
    public class ClienteService : IClienteService
    {
        public List<Cliente> ListarTodos()
        {
            ClienteComponent ClienteComponent = new ClienteComponent();
            return ClienteComponent.ListarTodos();
        }

        public Cliente Create(Cliente cliente)
        {
            ClienteComponent ClienteComponent = new ClienteComponent();
            return ClienteComponent.Agregar(cliente);
        }

        public bool Edit(Cliente cliente)
        {
            ClienteComponent ClienteComponent = new ClienteComponent();
            return ClienteComponent.Edit(cliente);
        }

        public Cliente GetByID(int ID)
        {
            ClienteComponent ClienteComponent = new ClienteComponent();
            return ClienteComponent.GetByID(ID);
        }

        public bool Delete(int ID)
        {
            ClienteComponent ClienteComponent = new ClienteComponent();
            return ClienteComponent.Delete(ID);
        }
    }
}
