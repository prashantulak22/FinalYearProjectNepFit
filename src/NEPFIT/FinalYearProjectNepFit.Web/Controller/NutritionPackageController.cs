using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NepFit.BL.Interface;
using NepFit.Repository.Dto;

namespace FinalYearProjectNepFit.Web.Controller
{
    public class NutritionPackageController : ControllerBase
    {
        private readonly INutritionPackageService _nutritionPackageService;

        public NutritionPackageController(INutritionPackageService nutritionPackageService)
        {
            _nutritionPackageService = nutritionPackageService;
        }

        // [Route("api/exercise/package")]
        // [HttpPost]
    }
}
