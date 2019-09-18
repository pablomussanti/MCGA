using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services.Contracts
{
    public interface IMedicoService
    {
        List<Medico> ListarTodos();
        Medico Create(Medico medico);
        bool Edit(Medico medico);
        Medico GetByID(int iD);
        bool Delete(int iD);
    }
}
