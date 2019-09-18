using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services.Contracts
{
    public interface ISalaService
    {
        List<Sala> ListarTodos();
        Sala Create(Sala sala);
        bool Edit(Sala sala);
        Sala GetByID(int iD);
        bool Delete(int iD);
    }
}