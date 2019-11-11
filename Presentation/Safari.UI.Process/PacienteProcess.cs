using Safari.Entities;
using Safari.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.UI.Process
{
    public class PacienteProcess : ProcessComponent
    {
        IPacienteService PacienteService = Framework.Common.ServiceFactory.Get<IPacienteService>();

        public List<Paciente> ListarTodos()
        {
            return PacienteService.ListarTodos();
        }

        public Paciente Create(Paciente Paciente)
        {
            return PacienteService.Create(Paciente);
        }

        public bool Edit(Paciente Paciente)
        {
            return PacienteService.Edit(Paciente);
        }

        public Paciente GetByID(int ID)
        {
            return PacienteService.GetByID(ID);
        }

        public bool Delete(int ID)
        {
            return PacienteService.Delete(ID);
        }
    }
}
