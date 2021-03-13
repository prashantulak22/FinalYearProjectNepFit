using NepFit.Repository.Dto;
using System.Collections.Generic;
namespace NepFit.BL.Interface
{
    public interface INutritionPackageRoutineService
    {
        int Add(NutritionPackageRoutineCreateDto input);
        bool Update(NutritionPackageRoutineUpdateDto input);
        IEnumerable<NutritionPackageRoutineResultDto> GetAll();
        bool Delete(NutritionPackageRoutineUpdateDto id);
    }
}
