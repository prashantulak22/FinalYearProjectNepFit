using System;
using System.Collections.Generic;
using NepFit.Repository.Dto;
using NepFit.Repository.Entity;

namespace NepFit.Repository.Repository.Interface
{
    public interface INepFitUserRepository
    {
        int Add(NepFitUser input);
        NepFitUser Update(NepFitUser input);
        IEnumerable<NepFitUserResultDto> GetAll();
        NepFitUser GetById(Guid id);
        bool Delete(NepFitUser input);
        
    }
}
