using NepFit.Repository.Dto;
using System;
using System.Collections.Generic;
namespace NepFit.BL.Interface
{
    public interface IUserNotesService
    {
        int Add(UserNotesCreateDto input);
        bool Update(UserNotesUpdateDto input);
        IEnumerable<UserNotesResultDto> GetAll();
        IEnumerable<UserNotesResultDto> GetByUserId(Guid userId);
        bool Delete(UserNotesUpdateDto id);
    }
}
