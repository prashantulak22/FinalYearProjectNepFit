using System;
using System.Collections.Generic;
using System.Text;
using NepFit.Repository.Dto;

namespace NepFit.BL.Interface
{
    public interface IExercisePackageService
    {
        int Add(ExercisePackageCreateDto inputDto);

        bool Update(ExercisePackageUpdateDto input);

        IEnumerable<ExercisePackageResultDto> GetAll();

        bool Delete(ExercisePackageUpdateDto id);
    }
}
