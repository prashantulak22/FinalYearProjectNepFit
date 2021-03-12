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

        public ExerciseRoutineController(IExerciseRoutineService ExerciseRoutineService)
        {
            _exerciseRoutineService = ExerciseRoutineService;
        }

        [Route("api/exerciseroutine/all")]
        [HttpGet]
        public IEnumerable<ExerciseRoutineResultDto> GetAll()
        {
            return _exerciseRoutineService.GetAll();
        }


        [Route("api/exerciseroutine/delete")]
        [HttpPost]
        public ActionResult<bool> Delete(ExerciseRoutineUpdateDto input)
        {
            if (TryValidateModel(input))
            {
                input.UpdatedBy = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                return _exerciseRoutineService.Delete(input);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Route("api/exerciseroutine/add")]
        [HttpPost]
        public ActionResult<int> Add(ExerciseRoutineCreateDto input)
        {

            if (TryValidateModel(input))
            {
                input.CreatedBy = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                return _exerciseRoutineService.Add(input);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Route("api/exerciseroutine/update")]
        [HttpPost]
        public ActionResult<bool> Update(ExerciseRoutineUpdateDto input)
        {

            if (TryValidateModel(input))
            {
                input.UpdatedBy = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                return _exerciseRoutineService.Update(input);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }

}