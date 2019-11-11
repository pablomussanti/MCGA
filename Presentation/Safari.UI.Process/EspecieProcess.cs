using Safari.Entities;
using Safari.Services;
using Safari.Services.Contracts;
using Safari.Services.Contracts.Requests;
using Safari.Services.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.UI.Process
{
    public class EspecieProcess :  ProcessComponent
    {
        IEspecieService Especie = new EspecieService();

        public List<Especie> ListarTodos()
        {
            return Especie.ListarTodos();
        }


        public IList<Especie> ToList()
        {
            var response = HttpGet<ListarTodosEspecieResponse>("api/Especie/ListarTodos", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }


        public Especie Agregarapi(Especie especie)
        {

            AgregarEspecieDto dto = new AgregarEspecieDto();
            dto.Result = especie;
            var request = HttpPost("api/Especie/Agregar", dto, MediaType.Json);
            return request.Result;
        }

        public Especie Create(Especie especie)
        {
            return Especie.Create(especie);
        }

        public bool Edit(Especie especie)
        {
            return Especie.Edit(especie);
        }

        public Especie GetByID(int ID)
        {
            return Especie.GetByID(ID);
        }

        public bool Delete(int ID)
        {
            return Especie.Delete(ID);
        }

    }
}
