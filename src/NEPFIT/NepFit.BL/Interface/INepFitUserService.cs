using System;
using System.Collections.Generic;
using NepFit.Repository.Dto;

namespace NepFit.BL.Interface
{
    public interface INepFitUserService
    {
        int Add(NepFitUserCreateDto input);
        bool Update(NepFitUserUpdateDto input);
        IEnumerable<NepFitUserResultDto> GetAll();
        bool Delete(NepFitUserUpdateDto id);

    }
}
