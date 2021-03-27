using System;
using System.Collections.Generic;
using NepFit.Repository.Dto;

namespace NepFit.BL.Interface
{
    public interface IUserExerciseNutritionService
    {
        int Add(UserExerciseNutritionCreateDto input);
        bool Update(UserExerciseNutritionUpdateDto input);
        IEnumerable<UserExerciseNutritionResultDto> GetAll();
        bool Delete(UserExerciseNutritionUpdateDto id);
    }
}
