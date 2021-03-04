using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NepFit.BL.Interface;
using NepFit.Repository.Dto;

namespace FinalYearProjectNepFit.Web.Controller
{
    public class NutritionRoutineController : ControllerBase
    {
        private readonly INutritionRoutineService _nutritionRoutineService;

        public NutritionRoutineController(INutritionRoutineService nutritionRoutineService)
        {
            _nutritionRoutineService = nutritionRoutineService;
        }

        // [Route("api/exercise/package")]
        // [HttpPost]
    }
}
