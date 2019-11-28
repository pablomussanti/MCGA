using Safari.Entities;
using Safari.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.UI.Process
{
    public class CitaProcess : ProcessComponent
    {
        ICitaService CitaServices = Framework.Common.ServiceFactory.Get<ICitaService>();

        public List<Cita> ListarTodos()
        {
            return CitaServices.ListarTodos();
        }

        public List<Cita> ListarTodosAuditor()
        {
            return CitaServices.ListarTodosAuditor();
        }

        public Cita Create(Cita Cita)
        {
            return CitaServices.Create(Cita);
        }

        public bool Edit(Cita Cita)
        {
            return CitaServices.Edit(Cita);
        }

        public Cita GetByID(int ID)
        {
            return CitaServices.GetByID(ID);
        }

        public bool Delete(int ID)
        {
            return CitaServices.Delete(ID);
        }
    }
}
