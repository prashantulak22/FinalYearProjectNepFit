using Common.Core;
using Common.Entities.SalarDb.CodeGen.Tables.Entity;
using Repository.Core.EntityFramework.Interfaces;

namespace SalarDb.CodeGen.Repository.Service
{
    public interface IExerciseRepository:  IEfRepository<Exercise> , ISingletonDependency
    {
   }
}
