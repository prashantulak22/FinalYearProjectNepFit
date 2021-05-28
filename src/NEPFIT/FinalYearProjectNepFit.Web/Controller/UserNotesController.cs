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
    public class UserNotesController : ControllerBase
    {
        private readonly IUserNotesService _userNotesService;

        public UserNotesController(IUserNotesService userNotesService)
        {
            _userNotesService = userNotesService;
        }

        [Route("api/usernotes/all")]
        [HttpGet]
        public IEnumerable<UserNotesResultDto> GetAll()
        {
            return _userNotesService.GetAll();
        }

        [Route("api/usernotes/notes")]
        [HttpGet]
        public IEnumerable<UserNotesResultDto> GetByUserId()
        {
            return _userNotesService.GetByUserId(new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier)));
        }

        [Route("api/usernotes/delete")]
        [HttpPost]
        public ActionResult<bool> Delete(UserNotesUpdateDto input)
        {
            if (TryValidateModel(input))
            {
                input.UpdatedBy = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                return _userNotesService.Delete(input);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Route("api/usernotes/add")]
        [HttpPost]
        public ActionResult<int> Add(UserNotesCreateDto input)
        {

            if (TryValidateModel(input))
            {
                input.UserId = input.CreatedBy = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                return _userNotesService.Add(input);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Route("api/usernotes/update")]
        [HttpPost]
        public ActionResult<bool> Update(UserNotesUpdateDto input)
        {

            if (TryValidateModel(input))
            {
                input.UpdatedBy = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                return _userNotesService.Update(input);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }

}
