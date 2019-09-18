using Safari.Data;
using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace Safari.Business
{
    public partial class EspecieComponent
    {
        public Especie Create(Especie especie)
        {
            Especie result = default(Especie);
            var especieDAC = new EspecieDAC();

            result = especieDAC.Create(especie);
            return result;
        }

        public List<Especie> ListarTodos()
        {
            List<Especie> result = default(List<Especie>);

            var especieDAC = new EspecieDAC();
            result = especieDAC.Read();
            return result;

        }

        public bool Delete(int iD)
        {
            var especieDAC = new EspecieDAC();
            try
            {
                especieDAC.Delete(iD);
                return true;
            }
            catch
            {
                Console.WriteLine("Error al eliminar el elemento");
                return false;
            }
        }

        public bool Edit(Especie especie)
        {
            var especiedac = new EspecieDAC();
            try
            {
                especiedac.Update(especie);
                return true;
            }
            catch
            {
                Console.WriteLine("Error al editar el elemento");
                return false;
            }
        }

        public Especie GetByID(int iD)
        {
            Especie result = default(Especie);
            var especieDAC = new EspecieDAC();

            result = especieDAC.ReadBy(iD);
            return result;
        }
    }
}
