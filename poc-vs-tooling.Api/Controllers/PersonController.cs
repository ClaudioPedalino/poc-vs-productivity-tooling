using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using poc_vs_tooling.Core.Models.Common;
using poc_vs_tooling.Core.Models.RequestDto;
using poc_vs_tooling.Core.Models.ResponseDto;
using poc_vs_tooling.Core.Services;
using poc_vs_tooling.Data;
using poc_vs_tooling.Data.Interfaces;
using poc_vs_tooling.Data.Repositories;
using System;
using System.Collections.Generic;


namespace poc_vs_tooling.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        //[CP] Refactor Me :)
        private readonly DataContext _dataContext;

        public PersonController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedResult<GetPersonResponseDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Result))]
        [Produces("application/json", Type = typeof(PaginatedResult<GetPersonResponseDto>))]
        public ActionResult<PaginatedResult<GetPersonResponseDto>> GetAll([FromQuery] GetPersonRequestDto request)
        {
            var service = new PersonService(new PersonRepository(_dataContext));
            var response = service.GetAll(request);

            return Ok(response);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Result))]
        [Produces("application/json", Type = typeof(Result))]
        public ActionResult<Result> Create([FromBody] CreatePersonRequestDto request)
        {
            var service = new PersonService(new PersonRepository(_dataContext));
            var response = service.Create(request);

            // [CP] Invertir if
            // [CP] Convertir en expresion condicional, 'ternario'
            if (response.HasErrors)
            {
                return BadRequest(response.Message);
            }
            return Ok(response);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Result))]
        [Produces("application/json", Type = typeof(Result))]
        public ActionResult<Result> Delete([FromRoute] Guid id)
        {
            var service = new PersonService(new PersonRepository(_dataContext));
            var response = service.Delete(id);

            return response.HasErrors 
                ? BadRequest(response.Message) 
                : (ActionResult<Result>)Ok(response);
        }
    }
}
