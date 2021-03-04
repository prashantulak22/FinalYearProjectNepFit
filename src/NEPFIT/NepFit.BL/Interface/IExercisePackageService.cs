using System;
using System.Collections.Generic;
using System.Text;
using NepFit.Repository.Dto;

namespace NepFit.BL.Interface
{
    public interface IExercisePackageService
    {
        int AddExercisePackage(ExercisePackageCreateDto inputDto);
    }
}
