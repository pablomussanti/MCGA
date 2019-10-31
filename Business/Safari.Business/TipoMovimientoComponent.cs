using Safari.Data;
using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Business
{
    public partial class TipoMovimientoComponent
    {
        public TipoMovimiento Create(TipoMovimiento TipoMovimiento)
        {
            TipoMovimiento result = default(TipoMovimiento);
            var TipoMovimientoDAC = new TipoMovimientoDAC();

            result = TipoMovimientoDAC.Create(TipoMovimiento);
            return result;
        }

        public List<TipoMovimiento> ListarTodos()
        {
            List<TipoMovimiento> result = default(List<TipoMovimiento>);

            var TipoMovimientoDAC = new TipoMovimientoDAC();
            result = TipoMovimientoDAC.Read();
            return result;

        }

        public TipoMovimiento GetByID(int ID)
        {
            TipoMovimiento result = default(TipoMovimiento);
            var TipoMovimientoDAC = new TipoMovimientoDAC();

            result = TipoMovimientoDAC.ReadBy(ID);
            return result;
        }

        public bool Edit(TipoMovimiento TipoMovimiento)
        {
            var TipoMovimientoDAC = new TipoMovimientoDAC();
            try
            {
                TipoMovimientoDAC.Update(TipoMovimiento);
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
            var TipoMovimientoDAC = new TipoMovimientoDAC();
            try
            {
                TipoMovimientoDAC.Delete(ID);
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
