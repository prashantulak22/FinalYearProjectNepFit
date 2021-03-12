using System;
using System.Collections.Generic;
using System.Text;
using NepFit.Repository.Dto;

namespace NepFit.BL.Interface
{
    public interface IExerciseRoutineService
    {
        int Add(ExerciseRoutineCreateDto input);
        bool Update(ExerciseRoutineUpdateDto input);
        IEnumerable<ExerciseRoutineResultDto> GetAll();
        bool Delete(ExerciseRoutineUpdateDto id);
    }
}
