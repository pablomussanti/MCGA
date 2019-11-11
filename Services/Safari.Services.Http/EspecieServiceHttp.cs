﻿using Safari.Business;
using Safari.Services.Contracts.Requests;
using Safari.Services.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Safari.Services.Http
{
    [RoutePrefix("api/Especie")]
    public class EspecieServiceHttp : ApiController
    {
        [HttpPost]
        [Route("Agregar")]
        public AgregarEspecieDto Agregar(AgregarEspecieDto dto)
        {
            try
            {

                var bc = new EspecieComponent();
                dto.Result = bc.Create(dto.Result);
                return dto;
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422, // UNPROCESSABLE ENTITY
                    ReasonPhrase = ex.Message
                };
                dto.Message = ex.Message;
                throw new HttpResponseException(httpError);
            }
        }

        [HttpGet]
        [Route("ListarTodos")]
        public ListarTodosEspecieResponse ListarTodos()
        {
            try
            {
                var response = new ListarTodosEspecieResponse();
                var bc = new EspecieComponent();
                response.Result = bc.ListarTodos();
                return response;
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422, // UNPROCESSABLE ENTITY
                    ReasonPhrase = ex.Message
                };
                throw new HttpResponseException(httpError);
            }
        }
    }
}
