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
    public class ExerciseTypeController : ControllerBase
    {
        private readonly IExerciseTypeService _exerciseTypeService;

        public ExerciseTypeController(IExerciseTypeService exerciseTypeService)
        {
            _exerciseTypeService = exerciseTypeService;
        }

        [Route("api/exercisetype/all")]
        [HttpGet]
        public IEnumerable<ExerciseTypeResultDto> GetAll()
        {
            return _exerciseTypeService.GetAll();
        }


        [Route("api/exercisetype/delete")]
        [HttpPost]
        public ActionResult<bool> Delete(ExerciseTypeUpdateDto input)
        {
            if (TryValidateModel(input))
            {
                input.UpdatedBy = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                return _exerciseTypeService.Delete(input);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Route("api/exercisetype/add")]
        [HttpPost]
        public ActionResult<int> Add(ExerciseTypeCreateDto input)
        {

            if (TryValidateModel(input))
            {
                input.CreatedBy = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                return _exerciseTypeService.Add(input);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Route("api/exercisetype/update")]
        [HttpPost]
        public ActionResult<bool> Update(ExerciseTypeUpdateDto input)
        {

            if (TryValidateModel(input))
            {
                input.UpdatedBy = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                return _exerciseTypeService.Update(input);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }

}
