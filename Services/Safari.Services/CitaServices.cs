using Safari.Entities;
using Safari.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Safari.Business;

namespace Safari.Services
{
    public class CitaServices : ICitaService
    {
        public List<Cita> ListarTodos()
        {
            CitaComponent CitaComponent = new CitaComponent();
            return CitaComponent.ListarTodos();
        }

        public Cita Create(Cita Cita)
        {
            CitaComponent CitaComponent = new CitaComponent();
            return CitaComponent.Agregar(Cita);
        }

        public bool Edit(Cita Cita)
        {
            CitaComponent CitaComponent = new CitaComponent();
            return CitaComponent.Edit(Cita);
        }

        public Cita GetByID(int ID)
        {
            CitaComponent CitaComponent = new CitaComponent();
            return CitaComponent.GetByID(ID);
        }
    }
}
