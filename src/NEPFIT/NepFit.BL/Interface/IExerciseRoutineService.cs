﻿using System;
using System.Collections.Generic;
using System.Text;
using NepFit.Repository.Dto;

namespace NepFit.BL.Interface
{
    public interface IExerciseRoutineService
    {
        int AddExerciseRoutine(ExerciseRoutineCreateDto inputDto);
    }
}
