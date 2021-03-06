using System;
using System.Collections.Generic;
using System.Text;
using NepFit.Repository.Entity;

namespace NepFit.Repository.Repository.Interface
{
    public interface IExercisePackageRepository
    {
        int Add(ExercisePackage input);

        ExercisePackage Update(ExercisePackage input);

        IEnumerable<ExercisePackage> GetAll();

        ExercisePackage GetById(Guid id);

        bool Delete(ExercisePackage input);
    }
}
