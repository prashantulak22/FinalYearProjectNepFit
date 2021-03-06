using System;
using System.Collections.Generic;
using NepFit.Repository.Dto;

namespace NepFit.BL.Interface
{
    public interface IExerciseTypeService
    {
        int Add(ExerciseTypeCreateDto input);
        bool Update(ExerciseTypeUpdateDto input);
        IEnumerable<ExerciseTypeResultDto> GetAll();
        bool Delete(Guid id);
    }
}
