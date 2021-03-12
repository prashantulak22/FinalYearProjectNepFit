using System;
using System.Collections.Generic;
using System.Text;
using NepFit.Repository.Entity;

namespace NepFit.Repository.Repository.Interface
{
    public interface IExerciseRoutineRepository
    {
        int Add(ExerciseRoutine input);

        ExerciseRoutine Update(ExerciseRoutine input);

        IEnumerable<ExerciseRoutine> GetAll();

        ExerciseRoutine GetById(Guid id);

        bool Delete(ExerciseRoutine id);


    }
}
