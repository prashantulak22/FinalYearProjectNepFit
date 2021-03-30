using System;
using System.Collections.Generic;
using NepFit.Repository.Dto;

namespace NepFit.BL.Interface
{
    public interface INutritionRoutineService
    {
        int Add(NutritionRoutineCreateDto input);
        bool Update(NutritionRoutineUpdateDto input);
        IEnumerable<NutritionRoutineResultDto> GetAll();
        bool Delete(NutritionRoutineUpdateDto id);

        IEnumerable<NutritionRoutineResultDto> GetByUserId(Guid id);
    }
}
