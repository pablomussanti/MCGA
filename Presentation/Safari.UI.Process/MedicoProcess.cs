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
    public class MedicoProcess
    {
        IMedicoService Medicoservices = new MedicoService();

        public List<Medico> ListarTodos()
        {
            return Medicoservices.ListarTodos();
        }

        public Medico Create(Medico medico)
        {
            return Medicoservices.Create(medico);
        }

        public bool Edit(Medico medico)
        {
            return Medicoservices.Edit(medico);
        }

        public Medico GetByID(int ID)
        {
            return Medicoservices.GetByID(ID);
        }

        public bool Delete(int ID)
        {
            return Medicoservices.Delete(ID);
        }

    }
}
