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

    public class ExercisePackageController : ControllerBase
    {
        private readonly IExercisePackageService _exercisePackageService;

        public ExercisePackageController(IExercisePackageService exercisePackageService)
        {
            _exercisePackageService = exercisePackageService;
        }

       // [Route("api/exercise/package")]
       // [HttpPost]
    }
}
