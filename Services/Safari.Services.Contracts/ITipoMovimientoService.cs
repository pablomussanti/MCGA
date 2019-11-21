using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services.Contracts
{
    public interface ITipoMovimientoService
    {
        List<TipoMovimiento> ListarTodos();
        TipoMovimiento Create(TipoMovimiento TipoMovimiento);
        bool Edit(TipoMovimiento TipoMovimiento);
        TipoMovimiento GetByID(int iD);
        bool Delete(int iD);
    }
}
