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
    public class SalaProcess
    {
        ISalaService Salaservices = new SalaServices();

        public List<Sala> ListarTodos()
        {
            return Salaservices.ListarTodos();
        }

        public Sala Create(Sala sala)
        {
            return Salaservices.Create(sala);
        }

        public bool Edit(Sala sala)
        {
            return Salaservices.Edit(sala);
        }

        public Sala GetByID(int ID)
        {
            return Salaservices.GetByID(ID);
        }

        public bool Delete(int ID)
        {
            return Salaservices.Delete(ID);
        }

    }
}
