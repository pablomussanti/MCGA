using Safari.Data;
using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Business
{
    public partial class MedicoComponent
    {
        public Medico Agregar(Medico medico)
        {
            Medico result = default(Medico);
            var medicoDAC = new MedicoDAC();

            result = medicoDAC.Create(medico);
            return result;
        }

        public List<Medico> ListarTodos()
        {
            List<Medico> result = default(List<Medico>);

            var medicoDAC = new MedicoDAC();
            result = medicoDAC.Read();
            return result;

        }

        public Medico GetByID(int ID)
        {
            Medico result = default(Medico);
            var medicoDAC = new MedicoDAC();

            result = medicoDAC.ReadBy(ID);
            return result;
        }

        public bool Edit(Medico medico)
        {
            var medicoDAC = new MedicoDAC();
            try
            {
                medicoDAC.Update(medico);
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
            var medicoDAC = new MedicoDAC();
            try
            {
                medicoDAC.Delete(ID);
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
