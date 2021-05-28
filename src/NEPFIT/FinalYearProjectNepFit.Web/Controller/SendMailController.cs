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
    public class SendMailController : ControllerBase
    {
        private readonly ISendMailService _sendMailService;
        public SendMailController(ISendMailService sendMailService)
        {
            _sendMailService = sendMailService;
        }

        [Route("api/sendmail/add")]
        [HttpPost]
        public ActionResult<int> Add(SendMailCreateDto input)
        {

            if (TryValidateModel(input))
            {
                input.UserId = input.CreatedBy = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                return _sendMailService.Add(input);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }


    }
}
