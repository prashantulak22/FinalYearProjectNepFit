using NepFit.Repository.Dto;
using System;
using System.Collections.Generic;

namespace NepFit.Repository.Repository.Interface
{
    public interface INutritionPackageRoutineRepository
    {
        int Add(NutritionPackageRoutine input);
        int Update(NutritionPackageRoutine input);
        IEnumerable<NutritionPackageRoutineResultDto> GetAll();
        NutritionPackageRoutine GetById(Guid id);
        bool Delete(NutritionPackageRoutine input);
    }
}
