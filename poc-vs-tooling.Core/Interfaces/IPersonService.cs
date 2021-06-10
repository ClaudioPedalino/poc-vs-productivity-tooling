using poc_vs_tooling.Core.Models.Common;
using poc_vs_tooling.Core.Models.RequestDto;
using poc_vs_tooling.Core.Models.ResponseDto;
using System;
using System.Collections.Generic;

namespace poc_vs_tooling.Core.Interfaces
{
    public interface IPersonService
    {
        PaginatedResult<GetPersonResponseDto> GetAll(GetPersonRequestDto request);
        Result Create(CreatePersonRequestDto request);
        Result Delete(Guid id);
    }
}