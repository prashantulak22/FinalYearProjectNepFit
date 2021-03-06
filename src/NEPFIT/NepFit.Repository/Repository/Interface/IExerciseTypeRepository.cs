using System;
using System.Collections.Generic;
using NepFit.Repository.Entity;

namespace NepFit.Repository.Repository.Interface
{
    public interface IExerciseTypeRepository
    {
        int Add(ExerciseType input);
        ExerciseType Update(ExerciseType input);
        IEnumerable<ExerciseType> GetAll();
        bool Delete(Guid id);
    }
}
