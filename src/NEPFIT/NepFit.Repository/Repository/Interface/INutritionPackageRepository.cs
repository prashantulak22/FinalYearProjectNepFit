using System;
using System.Collections.Generic;
using NepFit.Repository.Entity;

namespace NepFit.Repository.Repository.Interface
{
    public interface INutritionPackageRepository
    {
        int Add(NutritionPackage input);
        NutritionPackage Update(NutritionPackage input);
        IEnumerable<NutritionPackage> GetAll();
        NutritionPackage GetById(Guid id);
        bool Delete(NutritionPackage input);
    }
}
