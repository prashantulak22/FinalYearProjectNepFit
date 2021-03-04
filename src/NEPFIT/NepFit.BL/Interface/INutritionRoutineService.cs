using System;
using System.Collections.Generic;
using System.Text;
using NepFit.Repository.Dto;

namespace NepFit.BL.Interface
{
    public interface INutritionRoutineService
    {
        int AddNutritionRoutine(NutritionRoutineCreateDto inputDto);
    }
}
