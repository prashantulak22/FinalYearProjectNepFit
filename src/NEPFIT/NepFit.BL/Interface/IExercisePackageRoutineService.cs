using NepFit.Repository.Dto;
using System.Collections.Generic;
namespace NepFit.BL.Interface
{
    public interface IExercisePackageRoutineService
    {
        int Add(ExercisePackageRoutineCreateDto input);
        bool Update(ExercisePackageRoutineUpdateDto input);
        IEnumerable<ExercisePackageRoutineResultDto> GetAll();
        bool Delete(ExercisePackageRoutineUpdateDto id);
    }
}
