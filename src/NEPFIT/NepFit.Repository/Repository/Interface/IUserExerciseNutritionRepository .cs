﻿using System;
using System.Collections.Generic;
using System.Text;
using NepFit.Repository.Entity;

namespace NepFit.Repository.Repository.Interface
{
    public interface IUserExerciseNutritionRepository 
    {
        int Add(UserExerciseNutrition input);
       
        UserExerciseNutrition Update(UserExerciseNutrition input);
        IEnumerable<UserExerciseNutrition> GetAll();
        UserExerciseNutrition GetById(Guid id);
        bool Delete(UserExerciseNutrition input);

    }
}
