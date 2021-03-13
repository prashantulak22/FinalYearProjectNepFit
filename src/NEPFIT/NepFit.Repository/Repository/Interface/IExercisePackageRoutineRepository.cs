using NepFit.Repository.Entity;
using System;
using System.Collections.Generic;

namespace NepFit.Repository.Repository.Interface
{
    public interface IExercisePackageRoutineRepository
    {
        int Add(ExercisePackageRoutine input);
        int Update(ExercisePackageRoutine input);
        IEnumerable<ExercisePackageRoutine> GetAll();
        ExercisePackageRoutine GetById(Guid id);
        bool Delete(ExercisePackageRoutine input);
    }
}
