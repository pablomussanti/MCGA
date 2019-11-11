using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services.Contracts
{

        public interface IPacienteService
        {
            List<Paciente> ListarTodos();
            Paciente GetByID(int iD);
            bool Delete(int iD);
            bool Edit(Paciente Paciente);
            Paciente Create(Paciente Paciente);
        }
    
}
