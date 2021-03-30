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
    public class NutritionRoutineController : ControllerBase
    {
        private readonly INutritionRoutineService _nutritionRoutineService;

        public NutritionRoutineController(INutritionRoutineService nutritionRoutineService)
        {
            _nutritionRoutineService = nutritionRoutineService;
        }

        [Route("api/nutritionroutine/all")]
        [HttpGet]
        public IEnumerable<NutritionRoutineResultDto> GetAll()
        {
            return _nutritionRoutineService.GetAll();
        }



        [Route("api/nutritionroutine/user")]
        [HttpGet]
        public IEnumerable<NutritionRoutineResultDto> GetByUserId()
        {
            return _nutritionRoutineService.GetByUserId(new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier)));
        }



        [Route("api/nutritionroutine/delete")]
        [HttpPost]
        public ActionResult<bool> Delete(NutritionRoutineUpdateDto input)
        {
            if (TryValidateModel(input))
            {
                input.UpdatedBy = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                return _nutritionRoutineService.Delete(input);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Route("api/nutritionroutine/add")]
        [HttpPost]
        public ActionResult<int> Add(NutritionRoutineCreateDto input)
        {

            if (TryValidateModel(input))
            {
                input.CreatedBy = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                return _nutritionRoutineService.Add(input);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Route("api/nutritionroutine/update")]
        [HttpPost]
        public ActionResult<bool> Update(NutritionRoutineUpdateDto input)
        {

            if (TryValidateModel(input))
            {
                input.UpdatedBy = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                return _nutritionRoutineService.Update(input);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }

}
