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
    public class NutritionTypeController : ControllerBase
    {
        private readonly INutritionTypeService _nutritionTypeService;

        public NutritionTypeController(INutritionTypeService nutritionTypeService)
        {
            _nutritionTypeService = nutritionTypeService;
        }

        [Route("api/nutritiontype/all")]
        [HttpGet]
        public IEnumerable<NutritionTypeResultDto> GetAll()
        {
            return _nutritionTypeService.GetAll();
        }


        [Route("api/nutritiontype/delete")]
        [HttpDelete]
        public ActionResult<bool> Delete(NutritionTypeUpdateDto input)
        {
            if (TryValidateModel(input))
            {
                input.UpdatedBy = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                return _nutritionTypeService.Delete(input);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Route("api/nutritiontype/add")]
        [HttpPost]
        public ActionResult<int> Add(NutritionTypeCreateDto input)
        {

            if (TryValidateModel(input))
            {
                input.CreatedBy = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                return _nutritionTypeService.Add(input);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Route("api/nutritiontype/update")]
        [HttpPost]
        public ActionResult<bool> Update(NutritionTypeUpdateDto input)
        {

            if (TryValidateModel(input))
            {
                input.UpdatedBy = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                return _nutritionTypeService.Update(input);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }

}
