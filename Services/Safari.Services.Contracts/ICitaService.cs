using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services.Contracts
{
    public interface ICitaService
    {
        List<Cita> ListarTodos();
        List<Cita> ListarTodosAuditor();
        Cita GetByID(int iD); 
        bool Edit(Cita Cita);
        Cita Create(Cita Cita);
        bool Delete(int iD);
    }
}
