using Safari.Data;
using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Business
{
    public partial class PrecioComponent
    {

        public Precio Agregar(Precio Precio)
        {
            Precio result = default(Precio);
            var PrecioDAC = new PrecioDAC();

            result = PrecioDAC.Create(Precio);
            return result;
        }

        public List<Precio> ListarTodos()
        {
            List<Precio> result = default(List<Precio>);

            var PrecioDAC = new PrecioDAC();
            result = PrecioDAC.Read();
            return result;

        }

        public Precio GetByID(int ID)
        {
            Precio result = default(Precio);
            var PrecioDAC = new PrecioDAC();

            result = PrecioDAC.ReadBy(ID);
            return result;
        }

        public bool Edit(Precio Precio)
        {
            var PrecioDAC = new PrecioDAC();
            try
            {
                PrecioDAC.Update(Precio);
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
            var PrecioDAC = new PrecioDAC();
            try
            {
                PrecioDAC.Delete(ID);
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
