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
    public class NepFitUserController : ControllerBase
    {
        private readonly INepFitUserService _nepFitUserService;

        public NepFitUserController(INepFitUserService nepFitUserService)
        {
            _nepFitUserService = nepFitUserService;
        }

        [Route("api/nepFitUser/all")]
        [HttpGet]
        public IEnumerable<NepFitUserResultDto> GetAll()
        {
            return _nepFitUserService.GetAll();
        }

        [Route("api/nepFitUser")]
        [HttpGet]
        public  NepFitUserResultDto GetLoggedInUser()
        {
            return _nepFitUserService.GetByUserId(new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier)));
        }

        [Route("api/nepFitUser/delete")]
        [HttpPost]
        public ActionResult<bool> Delete(NepFitUserUpdateDto input)
        {
            if (TryValidateModel(input))
            {
                input.UpdatedBy = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                return _nepFitUserService.Delete(input);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Route("api/nepFitUser/add")]
        [HttpPost]
        public ActionResult<int> Add(NepFitUserCreateDto input)
        {

            if (TryValidateModel(input))
            {
                input.CreatedBy = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                
                return _nepFitUserService.Add(input);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Route("api/nepFitUser/update")]
        [HttpPost]
        public ActionResult<bool> Update(NepFitUserUpdateDto input)
        {

            if (TryValidateModel(input))
            {
                input.UpdatedBy = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                return _nepFitUserService.Update(input);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
