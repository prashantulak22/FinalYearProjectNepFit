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

        [Route("api/exercisepackage/all")]
        [HttpGet]
        public IEnumerable<ExercisePackageResultDto> GetAll()
        {
            return _exercisePackageService.GetAll();
        }

        [Route("api/exercisepackage/delete")]
        [HttpPost]
        public ActionResult<bool> Delete(ExercisePackageUpdateDto input)
        {
            if (TryValidateModel(input))
            {
                input.UpdatedBy = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                return _exercisePackageService.Delete(input);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Route("api/exercisepackage/add")]
        [HttpPost]
        public ActionResult<int> Add(ExercisePackageCreateDto input)
        {

            if (TryValidateModel(input))
            {
                input.CreatedBy = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                return _exercisePackageService.Add(input);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Route("api/exercisepackage/update")]
        [HttpPost]
        public ActionResult<bool> Update(ExercisePackageUpdateDto input)
        {

            if (TryValidateModel(input))
            {
                input.UpdatedBy = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                return _exercisePackageService.Update(input);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }


    }
}
