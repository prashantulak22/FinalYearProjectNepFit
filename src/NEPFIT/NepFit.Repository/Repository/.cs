using System.Collections.Generic;
using Common.Entities.SalarDb.CodeGen;
using Common.Entities.SalarDb.CodeGen.Tables.Entity;
using Repository.Core.Infrastructure;
namespace Common.Repository.SalarDb.CodeGen.Entity
{
    public class NutritionRoutineRepository:  EntityRepository <NutritionRoutine, > , INutritionRoutineRepository  
    {
            public NutritionRoutineRepository(IServiceLocator serviceLocator)
            : base(serviceLocator)
        {

        }
   }
}
