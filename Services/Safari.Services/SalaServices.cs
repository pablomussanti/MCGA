using Safari.Business;
using Safari.Entities;
using Safari.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services
{
    public class SalaServices : ISalaService
    {
        public Sala Create(Sala sala)
        {
            SalaComponent Salacomponent = new SalaComponent();
            return Salacomponent.Agregar(sala);
        }

        public bool Delete(int iD)
        {
            SalaComponent Salacomponent = new SalaComponent();
            return Salacomponent.Delete(iD);
        }

        public bool Edit(Sala sala)
        {
            SalaComponent Salacomponent = new SalaComponent();
            return Salacomponent.Edit(sala);
        }

        public Sala GetByID(int iD)
        {
            SalaComponent Salacomponent = new SalaComponent();
            return Salacomponent.GetByID(iD);
        }

        public List<Sala> ListarTodos()
        {
            SalaComponent Salacomponent = new SalaComponent();
            return Salacomponent.ListarTodos();
        }
    }
}
