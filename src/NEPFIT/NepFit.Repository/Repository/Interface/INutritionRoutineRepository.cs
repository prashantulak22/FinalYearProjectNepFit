﻿using System;
using System.Collections.Generic;
using NepFit.Repository.Entity;

namespace NepFit.Repository.Repository.Interface
{
    public interface INutritionRoutineRepository
    {
        int Add(NutritionRoutine input);
        NutritionRoutine Update(NutritionRoutine input);
        IEnumerable<NutritionRoutine> GetAll();
        NutritionRoutine GetById(Guid id);
        bool Delete(NutritionRoutine input);
    }
}
