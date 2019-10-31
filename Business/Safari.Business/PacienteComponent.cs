using Safari.Data;
using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Business
{
    public partial class PacienteComponent
    {
        public Paciente Agregar(Paciente paciente)
        {
            Paciente result = default(Paciente);
            var pacienteDAC = new PacienteDAC();

            result = pacienteDAC.Create(paciente);
            return result;
        }

        public List<Paciente> ListarTodos()
        {
            List<Paciente> result = default(List<Paciente>);

            var pacienteDAC = new PacienteDAC();
            result = pacienteDAC.Read();
            return result;

        }

        public Paciente GetByID(int ID)
        {
            Paciente result = default(Paciente);
            var pacienteDAC = new PacienteDAC();

            result = pacienteDAC.ReadBy(ID);
            return result;
        }

        public bool Edit(Paciente paciente)
        {
            var pacienteDAC = new PacienteDAC();
            try
            {
                pacienteDAC.Update(paciente);
                return true;
            }
            catch
            {
                Console.WriteLine("Error al editar el elemento");
                return false;
            }

        }

        public bool Delete(int ID)
        {
            var pacienteDAC = new PacienteDAC();
            try
            {
                pacienteDAC.Delete(ID);
                return true;
            }
            catch
            {
                Console.WriteLine("Error al eliminar el elemento");
                return false;
            }

        }

    }
}
