using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services.Contracts
{
    public interface ITipoServicio
    {
        List<TipoServicio> ListarTodos();
        TipoServicio GetByID(int iD);
        bool Delete(int iD);
        bool Edit(TipoServicio especie);
        TipoServicio Create(TipoServicio especie);
    }
}
