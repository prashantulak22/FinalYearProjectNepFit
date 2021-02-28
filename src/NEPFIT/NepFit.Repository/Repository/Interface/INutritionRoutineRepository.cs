using System;
using System.Collections.Generic;
using System.Text;
using NepFit.Repository.Entity;

namespace NepFit.Repository.Repository.Interface
{
    public interface INutritionRoutineRepository
    {
        int Add(NutritionRoutine input);
    }
}
