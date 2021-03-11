using System;
using System.Collections.Generic;
using NepFit.Repository.Dto;

namespace NepFit.BL.Interface
{
    public interface INutritionPackageService
    {
        int Add(NutritionPackageCreateDto input);
        bool Update(NutritionPackageUpdateDto input);
        IEnumerable<NutritionPackageResultDto> GetAll();
        bool Delete(NutritionPackageUpdateDto id);
    }
}
