using NepFit.Repository.Dto;
using NepFit.Repository.Entity;
using System;
using System.Collections.Generic;

namespace NepFit.Repository.Repository.Interface
{
    public interface IExercisePackageRoutineRepository
    {
        int Add(ExercisePackageRoutine input);
        int Update(ExercisePackageRoutine input);
        IEnumerable<ExercisePackageRoutineResultDto> GetAll();
        ExercisePackageRoutine GetById(Guid id);
        bool Delete(ExercisePackageRoutine input);
    }
}
