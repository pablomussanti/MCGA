using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services.Contracts
{
    public interface IMovimientoService
    {
        List<Movimiento> ListarTodos();
        Movimiento Create(Movimiento Movimiento);
        bool Edit(Movimiento Movimiento);
        Movimiento GetByID(int iD);
        bool Delete(int iD);
    }
}
