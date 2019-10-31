using Safari.Data;
using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Business
{
    public partial class TipoServicioComponent
    {
        public TipoServicio Create(TipoServicio tiposervicio)
        {
            TipoServicio result = default(TipoServicio);
            var tiposervicioDAC = new TipoServicioDAC();

            result = tiposervicioDAC.Create(tiposervicio);
            return result;
        }

        public List<TipoServicio> ListarTodos()
        {
            List<TipoServicio> result = default(List<TipoServicio>);

            var tiposervicioDAC = new TipoServicioDAC();
            result = tiposervicioDAC.Read();
            return result;

        }

        public TipoServicio GetByID(int ID)
        {
            TipoServicio result = default(TipoServicio);
            var tiposervicioDAC = new TipoServicioDAC();

            result = tiposervicioDAC.ReadBy(ID);
            return result;
        }

        public bool Edit(TipoServicio tiposervicio)
        {
            var tiposervicioDAC = new TipoServicioDAC();
            try
            {
                tiposervicioDAC.Update(tiposervicio);
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
            var tiposervicioDAC = new TipoServicioDAC();
            try
            {
                tiposervicioDAC.Delete(ID);
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
