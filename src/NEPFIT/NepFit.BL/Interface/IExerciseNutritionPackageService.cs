using System;
using System.Collections.Generic;
using NepFit.Repository.Dto;

namespace NepFit.BL.Interface
{
    public interface IExerciseNutritionPackageService
    {
        int Add(ExerciseNutritionPackageCreateDto input);
        bool Update(ExerciseNutritionPackageUpdateDto input);
        IEnumerable<ExerciseNutritionPackageResultDto> GetAll();
        bool Delete(ExerciseNutritionPackageUpdateDto id);
    }
}
