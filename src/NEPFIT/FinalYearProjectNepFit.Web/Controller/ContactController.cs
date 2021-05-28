using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NepFit.BL.Interface;
using NepFit.Repository.Dto;

namespace FinalYearProjectNepFit.Web.Controller
{
    [ApiController]
    [Authorize]
    public class ContactController : ControllerBase
    {
        private readonly IEmailSender _sendMailService;
        private readonly IConfiguration _configuration;
        public ContactController(IEmailSender sendMailService, IConfiguration configuration)
        {
            _sendMailService = sendMailService;
            _configuration = configuration;
        }

        [Route("api/contact/us")]
        [HttpPost]
        public async Task<ActionResult> ContactUs(SendMailDto input)
        {

            if (TryValidateModel(input))
            {
                await _sendMailService.SendEmailAsync(_configuration["EmailSender:UserName"],
                       $"{input.Subject} Email=>{input.Email}",
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
