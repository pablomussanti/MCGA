using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services.Contracts
{
    public interface IPrecioService
    {
        List<Precio> ListarTodos();
        Precio GetByID(int iD);
        bool Delete(int iD);
        bool Edit(Precio Precio);
        Precio Create(Precio Precio);
    }
}
