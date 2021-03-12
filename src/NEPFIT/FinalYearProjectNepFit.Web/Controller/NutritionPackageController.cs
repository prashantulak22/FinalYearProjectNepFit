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
    public class NutritionPackageController : ControllerBase
    {
        private readonly INutritionPackageService _nutritionPackageService;

        public NutritionPackageController(INutritionPackageService nutritionPackageService)
        {
            _nutritionPackageService = nutritionPackageService;
        }

        [Route("api/nutritionpackage/all")]
        [HttpGet]
        public IEnumerable<NutritionPackageResultDto> GetAll()
        {
            return _nutritionPackageService.GetAll();
        }


        [Route("api/nutritionpackage/delete")]
        [HttpPost]
        public ActionResult<bool> Delete(NutritionPackageUpdateDto input)
        {
            if (TryValidateModel(input))
            {
                input.UpdatedBy = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                return _nutritionPackageService.Delete(input);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Route("api/nutritionpackage/add")]
        [HttpPost]
        public ActionResult<int> Add(NutritionPackageCreateDto input)
        {

            if (TryValidateModel(input))
            {
                input.CreatedBy = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                return _nutritionPackageService.Add(input);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Route("api/nutritionpackage/update")]
        [HttpPost]
        public ActionResult<bool> Update(NutritionPackageUpdateDto input)
        {

            if (TryValidateModel(input))
            {
                input.UpdatedBy = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                return _nutritionPackageService.Update(input);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }

}
