﻿using Safari.Entities;
using Safari.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Business
{
    public partial class CitaComponent
    {

        public Cita Agregar(Cita Cita)
        {
            Cita result = default(Cita);
            var CitaDAC = new CitaDAC();

            result = CitaDAC.Create(Cita);
            return result;
        }

        public List<Cita> ListarTodos()
        {
            List<Cita> result = default(List<Cita>);

            var CitaDAC = new CitaDAC();
            result = CitaDAC.Read();
            return result;

        }

        public List<Cita> ListarTodosAuditor()
        {
            List<Cita> result = default(List<Cita>);

            var CitaDAC = new CitaDAC();
            result = CitaDAC.Readcompleto();
            return result;

        }

        public Cita GetByID(int ID)
        {
            Cita result = default(Cita);
            var CitaDAC = new CitaDAC();

            result = CitaDAC.ReadBy(ID);
            return result;
        }

        public bool Edit(Cita Cita)
        {
            var CitaDAC = new CitaDAC();
            try
            {
                CitaDAC.Update(Cita);
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error al editar el elemento");
                return false;
            }

        }
        public bool Delete(int ID)
        {
            var citadac = new CitaDAC();
            try
            {
                citadac.Delete(ID);
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
