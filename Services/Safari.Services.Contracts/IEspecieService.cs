using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services.Contracts
{
    public interface IEspecieService
    {
        List<Especie> ListarTodos();
        Especie GetByID(int iD);
        bool Delete(int iD);
        bool Edit(Especie especie);
        Especie Create(Especie especie);
    }

}
