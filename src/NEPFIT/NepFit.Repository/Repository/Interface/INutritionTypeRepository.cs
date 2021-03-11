using NepFit.Repository.Entity;
using System;
using System.Collections.Generic;


namespace NepFit.Repository.Repository.Interface
{
    public interface INutritionTypeRepository
    {
        int Add(NutritionType input);
        NutritionType Update(NutritionType input);
        IEnumerable<NutritionType> GetAll();
        NutritionType GetById(Guid id);
        bool Delete(NutritionType input);
    }
}
