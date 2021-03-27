using System;
using System.Collections.Generic;
using NepFit.Repository.Dto;
using NepFit.Repository.Entity;

namespace NepFit.Repository.Repository.Interface
{
    public interface IExerciseNutritionPackageRepository
    {
        int Add(ExerciseNutritionPackage input);
        ExerciseNutritionPackage Update(ExerciseNutritionPackage input);
        IEnumerable<ExerciseNutritionPackageResultDto> GetAll();
        ExerciseNutritionPackage GetById(Guid id);
        bool Delete(ExerciseNutritionPackage input);
    }
}
