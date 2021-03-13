using NepFit.Repository.Dto;
using System;
using System.Collections.Generic;

namespace NepFit.Repository.Repository.Interface
{
    public interface INutritionPackageRoutineRepository
    {
        int Add(Guid input);
        int Update(Guid input);
        IEnumerable<NutritionPackageRoutine> GetAll();
        NutritionPackageRoutine GetById(Guid id);
        bool Delete(NutritionPackageRoutine input);
    }
}
