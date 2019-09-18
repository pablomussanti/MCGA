using Safari.Entities;
using Safari.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Safari.Business;

namespace Safari.Services
{
    public class MedicoService : IMedicoService
    {
        public Medico Create(Medico medico)
        {
            MedicoComponent Medicocomponent = new MedicoComponent();
            return Medicocomponent.Agregar(medico);
        }

        public bool Delete(int iD)
        {
            MedicoComponent Medicocomponent = new MedicoComponent();
            return Medicocomponent.Delete(iD);
        }

        public bool Edit(Medico medico)
        {
            MedicoComponent Medicocomponent = new MedicoComponent();
            return Medicocomponent.Edit(medico);
        }

        public Medico GetByID(int iD)
        {
            MedicoComponent Medicocomponent = new MedicoComponent();
            return Medicocomponent.GetByID(iD);
        }

        public List<Medico> ListarTodos()
        {
            MedicoComponent Medicocomponent = new MedicoComponent();
            return Medicocomponent.ListarTodos();
        }
    }
}
