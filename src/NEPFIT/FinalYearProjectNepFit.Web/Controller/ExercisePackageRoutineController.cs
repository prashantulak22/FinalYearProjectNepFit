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
    public class ExercisePackageRoutineController : ControllerBase
    {
        private readonly IExercisePackageRoutineService _exercisePackageRoutineService;

        public ExercisePackageRoutineController(IExercisePackageRoutineService exercisePackageRoutineService)
        {
            _exercisePackageRoutineService = exercisePackageRoutineService;
        }

        [Route("api/exercisepackageroutine/all")]
        [HttpGet]
        public IEnumerable<ExercisePackageRoutineResultDto> GetAll()
        {
            return _exercisePackageRoutineService.GetAll();
        }


        [Route("api/exercisepackageroutine/delete")]
        [HttpPost]
        public ActionResult<bool> Delete(ExercisePackageRoutineUpdateDto input)
        {
            if (TryValidateModel(input))
            {
                input.UpdatedBy = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                return _exercisePackageRoutineService.Delete(input);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Route("api/exercisepackageroutine/add")]
        [HttpPost]
        public ActionResult<int> Add(ExercisePackageRoutineCreateDto input)
        {

            if (TryValidateModel(input))
            {
                input.CreatedBy = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                return _exercisePackageRoutineService.Add(input);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Route("api/exercisepackageroutine/update")]
        [HttpPost]
        public ActionResult<bool> Update(ExercisePackageRoutineUpdateDto input)
        {

            if (TryValidateModel(input))
            {
                input.UpdatedBy = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                return _exercisePackageRoutineService.Update(input);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }

}
