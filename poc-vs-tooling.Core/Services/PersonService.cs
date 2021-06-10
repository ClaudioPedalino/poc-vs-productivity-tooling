using Microsoft.EntityFrameworkCore;
using poc_vs_tooling.Core.Entities;
using poc_vs_tooling.Core.Extensions;
using poc_vs_tooling.Core.Helpers;
using poc_vs_tooling.Core.Models.Common;
using poc_vs_tooling.Core.Models.RequestDto;
using poc_vs_tooling.Core.Models.ResponseDto;
using poc_vs_tooling.Data.Interfaces;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;

namespace poc_vs_tooling.Core.Services
{
    public class PersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public PaginatedResult<GetPersonResponseDto> GetAll(GetPersonRequestDto request)
        {
            // [CP] Add debugger display
            var results = _personRepository.GetAll().AsQueryable().AsNoTracking();
            if (!results.Any())
                return new PaginatedResult<GetPersonResponseDto>(new List<GetPersonResponseDto>()) { Message = "No hay resultados" };


            ///filtramos
            // [CP] Extraer en método
            var filterResults = results
                .WhereIf(!string.IsNullOrWhiteSpace(request.FirstName), x => x.FirstName.Contains(request.FirstName))
                .WhereIf(!string.IsNullOrWhiteSpace(request.LastName), x => x.LastName.Contains(request.LastName))
                .WhereIf(request.BirthdayFrom.HasValue, x => x.Birthday.Date >= request.BirthdayFrom.Value.Date)
                .WhereIf(request.BirthdayTo.HasValue, x => x.Birthday.Date <= request.BirthdayTo.Value)
                .WhereIf(!string.IsNullOrWhiteSpace(request.Email), x => x.Email.Contains(request.Email))
                .WhereIf(!string.IsNullOrWhiteSpace(request.Address), x => x.Address.Contains(request.Address))
                .WhereIf(!string.IsNullOrWhiteSpace(request.Phone), x => x.Phone.Contains(request.Phone));


            ///paginamos
            filterResults = filterResults
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize);


            ///mapeamos
            var response = new List<GetPersonResponseDto>();
            //[CP] Convertir en linqO
            foreach (var item in filterResults)
            {
                // [CP] Simplificar inicializacion
                var model = new GetPersonResponseDto();
                model.PersonId = item.PersonId;
                model.FirstName = item.FirstName;
                model.LastName = item.LastName;
                model.Birthday = item.Birthday.ToString("dd/MM/yyyy");
                model.Email = item.Email;
                model.Avatar = item.Avatar;
                model.Address = item.Address;
                model.Phone = item.Phone;
                response.Add(model);
            }

            return new PaginatedResult<GetPersonResponseDto>(
                data: response,
                totalCount: results.Count(),
                pageSize: request.PageSize,
                totalPages: PaginationHelper.GetPages(request.PageSize, results.Count())
            );
        }

        public Result Create(CreatePersonRequestDto request)
        {
            /// (01) VALIDACIONES 
            // [CP] Modificación recurrente
            if (request.FirstName == null || request.FirstName == "" || request.FirstName == " ")
                return new Result().Error($"{nameof(request.FirstName)} is invalid");

            if (request.LastName == null || request.LastName == "" || request.LastName == " ")
                return new Result().Error($"{nameof(request.LastName)} is invalid");

            if (request.Email == null || request.Email == "" || request.Email == " ")
                return new Result().Error($"{nameof(request.Email)} is invalid");

            if (request.Birthday.Date > DateTime.Now.Date)
                return new Result().Error($"{nameof(request.Birthday)} is invalid");

            if (request.Avatar == null || request.Avatar == "" || request.Avatar == " ")
                return new Result().Error($"{nameof(request.Avatar)} is invalid");

            if (request.Address == null || request.Address == "" || request.Address == " ")
                return new Result().Error($"{nameof(request.Address)} is invalid");

            if (request.Phone == null || request.Phone == "" || request.Phone == " ")
                return new Result().Error($"{nameof(request.Phone)} is invalid");


            /// (02) MAPEO
            var entity = new Person();
            entity.FirstName = request.FirstName;
            entity.LastName = request.LastName;
            entity.Birthday = request.Birthday;
            entity.Email = request.Email;
            entity.Avatar = request.Avatar;
            entity.Address = request.Address;
            entity.Phone = request.Phone;
            entity.CreatedAt = DateTime.UtcNow.AddHours(-3);


            /// (03) GUARDAR
            _personRepository.Create(entity);

            return new Result().Success($"Se creó el registro {entity.FirstName} {entity.LastName} correctamente");
        }


        public Result Delete(Guid id)
        {
            var entity = _personRepository.GetById(id);
            if (entity == null)
                return new Result().NotFound();

            _personRepository.Delete(entity);

            return new Result().Success("Se borró el registro correctamente");
        }

    }
}


