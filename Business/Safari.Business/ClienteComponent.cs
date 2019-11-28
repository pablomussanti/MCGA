using Safari.Data;
using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Business
{
    public partial class ClienteComponent
    {
        public Cliente Agregar(Cliente cliente)
        {
            Cliente result = default(Cliente);
            var clienteDAC = new ClienteDAC();

            result = clienteDAC.Create(cliente);
            return result;
        }

        public List<Cliente> ListarTodos()
        {
            List<Cliente> result = default(List<Cliente>);

            var clienteDAC = new ClienteDAC();
            result = clienteDAC.Read();
            return result;

        }

        public Cliente GetByID(int ID)
        {
            Cliente result = default(Cliente);
            var clienteDAC = new ClienteDAC();

            result = clienteDAC.ReadBy(ID);
            return result;
        }

        public bool Edit(Cliente cliente)
        {
            var clienteDAC = new ClienteDAC();
            try
            {
                clienteDAC.Update(cliente);
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
            var clienteDAC = new ClienteDAC();
            try
            {
                clienteDAC.Delete(ID);
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error al eliminar el elemento");
                return false;
            }

        }

    }
}
