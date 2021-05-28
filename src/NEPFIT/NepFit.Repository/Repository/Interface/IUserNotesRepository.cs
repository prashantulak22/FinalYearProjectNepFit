using NepFit.Repository.Dto;
using NepFit.Repository.Entity;
using System;
using System.Collections.Generic;

namespace NepFit.Repository.Repository.Interface
{
    public interface IUserNotesRepository
    {
        int Add(UserNotes input);
        UserNotes Update(UserNotes input);
        IEnumerable<UserNotesResultDto> GetAll();
        UserNotes GetById(Guid id);
        IEnumerable<UserNotes> GetByUserId(Guid id);
        bool Delete(UserNotes input);
    }
}