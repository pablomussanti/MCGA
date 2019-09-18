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
    public class EspecieProcess
    {
        IEspecieService Especie = new EspecieService();

        public List<Especie> ListarTodos()
        {
            return Especie.ListarTodos();
        }

        public Especie Create(Especie especie)
        {
            return Especie.Create(especie);
        }

        public bool Edit(Especie especie)
        {
            return Especie.Edit(especie);
        }

        public Especie GetByID(int ID)
        {
            return Especie.GetByID(ID);
        }

        public bool Delete(int ID)
        {
            return Especie.Delete(ID);
        }

    }
}
