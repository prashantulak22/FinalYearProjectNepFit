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
    public class ExerciseNutritionPackageController : ControllerBase
    {
        private readonly IExerciseNutritionPackageService _exerciseNutritionPackageService;
        private readonly INepFitUserService _nepFitUserService;

        public ExerciseNutritionPackageController(IExerciseNutritionPackageService exerciseNutritionPackageService, INepFitUserService nepFitUserService)
        {
            _exerciseNutritionPackageService = exerciseNutritionPackageService;
            _nepFitUserService = nepFitUserService;
        }

        [Route("api/exerciseNutritionPackage/all")]
        [HttpGet]
        public IEnumerable<ExerciseNutritionPackageResultDto> GetAll()
        {
            return _exerciseNutritionPackageService.GetAll();
        }


        [Route("api/exerciseNutritionPackage/delete")]
        [HttpPost]
        public ActionResult<bool> Delete(ExerciseNutritionPackageUpdateDto input)
        {
            if (_nepFitUserService.GetByUserId(new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier))).IsAdmin)
            {

                if (TryValidateModel(input))
                {
                    input.UpdatedBy = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                    return _exerciseNutritionPackageService.Delete(input);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            return Unauthorized();
        }

        [Route("api/exerciseNutritionPackage/add")]
        [HttpPost]
        public ActionResult<int> Add(ExerciseNutritionPackageCreateDto input)
        {

            if (TryValidateModel(input))
            {
                input.CreatedBy = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                return _exerciseNutritionPackageService.Add(input);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Route("api/exerciseNutritionPackage/update")]
        [HttpPost]
        public ActionResult<bool> Update(ExerciseNutritionPackageUpdateDto input)
        {

            if (TryValidateModel(input))
            {
                input.UpdatedBy = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                return _exerciseNutritionPackageService.Update(input);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
