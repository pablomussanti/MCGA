using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services.Contracts
{
    public interface IClienteService
    {
        List<Cliente> ListarTodos();
        Cliente Create(Cliente cliente);
        bool Edit(Cliente cliente);
        Cliente GetByID(int iD);
        bool Delete(int iD);
    }
}