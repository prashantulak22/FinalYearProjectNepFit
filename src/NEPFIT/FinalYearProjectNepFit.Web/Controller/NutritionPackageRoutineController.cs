using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NepFit.BL.Interface;
using NepFit.Repository.Dto;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace FinalYearProjectNepFit.Web.Controller
{
    [ApiController]
    [Authorize]
    public class NutritionPackageRoutineController : ControllerBase
    {
        private readonly INutritionPackageRoutineService _nutritionPackageRoutineService;

        public NutritionPackageRoutineController(INutritionPackageRoutineService nutritionPackageRoutineService)
        {
            _nutritionPackageRoutineService = nutritionPackageRoutineService;
        }

        [Route("api/nutritionpackageroutine/all")]
        [HttpGet]
        public IEnumerable<NutritionPackageRoutineResultDto> GetAll()
        {
            return _nutritionPackageRoutineService.GetAll();
        }


        [Route("api/nutritionpackageroutine/delete")]
        [HttpPost]
        public ActionResult<bool> Delete(NutritionPackageRoutineUpdateDto input)
        {
            if (TryValidateModel(input))
            {
                input.UpdatedBy = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                return _nutritionPackageRoutineService.Delete(input);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Route("api/nutritionpackageroutine/add")]
        [HttpPost]
        public ActionResult<int> Add(NutritionPackageRoutineCreateDto input)
        {

            if (TryValidateModel(input))
            {
                input.CreatedBy = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                return _nutritionPackageRoutineService.Add(input);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Route("api/nutritionpackageroutine/update")]
        [HttpPost]
        public ActionResult<bool> Update(NutritionPackageRoutineUpdateDto input)
        {

            if (TryValidateModel(input))
            {
                input.UpdatedBy = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                return _nutritionPackageRoutineService.Update(input);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }

}