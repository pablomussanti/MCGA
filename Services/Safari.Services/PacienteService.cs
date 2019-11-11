using Safari.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Safari.Services.Contracts;
using Safari.Entities;
using Safari.Business;

namespace Safari.Services
{
    public class PacienteService : IPacienteService
    {
        public List<Paciente> ListarTodos()
        {
            PacienteComponent PacienteComponent = new PacienteComponent();
            return PacienteComponent.ListarTodos();
        }

        public Paciente Create(Paciente Paciente)
        {
            PacienteComponent PacienteComponent = new PacienteComponent();
            return PacienteComponent.Agregar(Paciente);
        }

        public bool Edit(Paciente Paciente)
        {
            PacienteComponent PacienteComponent = new PacienteComponent();
            return PacienteComponent.Edit(Paciente);
        }

        public Paciente GetByID(int ID)
        {
            PacienteComponent PacienteComponent = new PacienteComponent();
            return PacienteComponent.GetByID(ID);
        }

        public bool Delete(int ID)
        {
            PacienteComponent PacienteComponent = new PacienteComponent();
            return PacienteComponent.Delete(ID);
        }
    }
}
