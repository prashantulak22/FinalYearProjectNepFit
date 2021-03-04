using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NepFit.BL.Interface;
using NepFit.Repository.Dto;

namespace FinalYearProjectNepFit.Web.Controller
{
    [ApiController]
    [Authorize]

    public class ExerciseRoutineController : ControllerBase
    {
        private readonly IExerciseRoutineService _exerciseRoutineService;

        public ExerciseRoutineController(IExerciseRoutineService exerciseRoutineService)
        {
            _exerciseRoutineService = exerciseRoutineService;
        }

        [Route("api/exercise/routine")]
        [HttpPost]
    }
}