using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Safari.Business;
using Safari.Entities;
using Safari.Services.Contracts;

namespace Safari.Services
{
    public class EspecieService : IEspecieService
    {
        public List<Especie> ListarTodos()
        {
            EspecieComponent EspecieComponent = new EspecieComponent();
            return EspecieComponent.ListarTodos();
        }

        public Especie Create(Especie especie)
        {
            EspecieComponent EspecieComponent = new EspecieComponent();
            return EspecieComponent.Create(especie);
        }

        public bool Edit(Especie especie)
        {
            EspecieComponent EspecieComponent = new EspecieComponent();
            return EspecieComponent.Edit(especie);
        }

        public Especie GetByID(int ID)
        {
            EspecieComponent EspecieComponent = new EspecieComponent();
            return EspecieComponent.GetByID(ID);
        }

        public bool Delete(int ID)
        {
            EspecieComponent EspecieComponent = new EspecieComponent();
            return EspecieComponent.Delete(ID);
        }
    }
}
