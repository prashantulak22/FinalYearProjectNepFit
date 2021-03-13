using NepFit.Repository.Entity;
using System;
using System.Collections.Generic;

namespace NepFit.Repository.Repository.Interface
{
    public interface IExercisePackageRoutineRepository
    {
        int Add(Guid input);
        int Update(Guid input);
        IEnumerable<ExercisePackageRoutine> GetAll();
        ExercisePackageRoutine GetById(Guid id);
        bool Delete(ExercisePackageRoutine input);
    }
}
