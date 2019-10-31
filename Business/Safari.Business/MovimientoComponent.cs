using Safari.Data;
using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Business
{
    public partial class MovimientoComponent
    {
        public Movimiento Create(Movimiento movimiento)
        {
            Movimiento result = default(Movimiento);
            var movimientoDAC = new MovimientoDAC();

            result = movimientoDAC.Create(movimiento);
            return result;
        }

        public List<Movimiento> ListarTodos()
        {
            List<Movimiento> result = default(List<Movimiento>);

            var movimientoDAC = new MovimientoDAC();
            result = movimientoDAC.Read();
            return result;

        }

        public Movimiento GetByID(int ID)
        {
            Movimiento result = default(Movimiento);
            var movimientoDAC = new MovimientoDAC();

            result = movimientoDAC.ReadBy(ID);
            return result;
        }

        public bool Edit(Movimiento movimiento)
        {
            var movimientoDAC = new MovimientoDAC();
            try
            {
                movimientoDAC.Update(movimiento);
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
            var movimientoDAC = new MovimientoDAC();
            try
            {
                movimientoDAC.Delete(ID);
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
