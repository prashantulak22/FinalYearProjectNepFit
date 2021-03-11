using System;
using System.Collections.Generic;
using NepFit.Repository.Dto;

namespace NepFit.BL.Interface
{
    public interface INutritionTypeService
    {
        int Add(NutritionTypeCreateDto input);
        bool Update(NutritionTypeUpdateDto input);
        IEnumerable<NutritionTypeResultDto> GetAll();
        bool Delete(NutritionTypeUpdateDto id);
    }
}
