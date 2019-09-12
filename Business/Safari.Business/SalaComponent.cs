using Safari.Data;
using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Business
{
    public partial class SalaComponent
    {
        public Sala Agregar(Sala sala)
        {
            Sala result = default(Sala);
            var salaDAC = new SalaDAC();

            result = salaDAC.Create(sala);
            return result;
        }

        public List<Sala> ListarTodos()
        {
            List<Sala> result = default(List<Sala>);

            var salaDAC = new SalaDAC();
            result = salaDAC.Read();
            return result;

        }

        public Sala GetByID(int ID)
        {
            Sala result = default(Sala);
            var salaDAC = new SalaDAC();

            result = salaDAC.ReadBy(ID);
            return result;
        }

        public bool Edit(Sala sala)
        {
            var salaDAC = new SalaDAC();
            try
            {
                salaDAC.Update(sala);
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
            var salaDAC = new SalaDAC();
            try
            {
                salaDAC.Delete(ID);
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
