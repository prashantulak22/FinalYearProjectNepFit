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
    public class UserExerciseNutritionController : ControllerBase
    {
        private readonly IUserExerciseNutritionService _userExerciseNutritionService;

        public UserExerciseNutritionController(IUserExerciseNutritionService UserExerciseNutritionService)
        {
            _userExerciseNutritionService = UserExerciseNutritionService;
        }

        [Route("api/userExerciseNutrition/all")]
        [HttpGet]
        public IEnumerable<UserExerciseNutritionResultDto> GetAll()
        {
            return _userExerciseNutritionService.GetAll();
        }


        [Route("api/userExerciseNutrition/delete")]
        [HttpPost]
        public ActionResult<bool> Delete(UserExerciseNutritionUpdateDto input)
        {
            if (TryValidateModel(input))
            {
                input.UpdatedBy = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                return _userExerciseNutritionService.Delete(input);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Route("api/userExerciseNutrition/add")]
        [HttpPost]
        public ActionResult<int> Add(UserExerciseNutritionCreateDto input)
        {

            if (TryValidateModel(input))
            {
                input.CreatedBy = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                return _userExerciseNutritionService.Add(input);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Route("api/userExerciseNutrition/update")]
        [HttpPost]
        public ActionResult<bool> Update(UserExerciseNutritionUpdateDto input)
        {

            if (TryValidateModel(input))
            {
                input.UpdatedBy = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                return _userExerciseNutritionService.Update(input);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
