using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using NepFit.BL.Interface;
using NepFit.Repository.Dto;

namespace FinalYearProjectNepFit.Web.Controller
{
    [ApiController]
    [Authorize]
    public class SendMailController : ControllerBase
    {
        private readonly IEmailSender _sendMailService;
        public SendMailController(IEmailSender sendMailService)
        {
            _sendMailService = sendMailService;
        }

        [Route("api/contact/us")]
        [HttpPost]
        public async Task<ActionResult> ContactUs(SendMailDto input)
        {

            if (TryValidateModel(input))
            {
                await _sendMailService.SendEmailAsync(input.Email,
                       input.Subject,
                       input.Message
                       );
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }


    }
}
