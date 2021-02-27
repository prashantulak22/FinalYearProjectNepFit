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
    public class ProgressTrackerController : ControllerBase
    {
        private readonly IProgressTrackerService _progressTrackerService;

        public ProgressTrackerController(IProgressTrackerService progressTrackerService)
        {
            _progressTrackerService = progressTrackerService;
        }


        [Route("api/user/progress")]
        [HttpGet]
        public IEnumerable<ProgressTrackerChartResultDto> GetUserProgress()
        {
            var userId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return _progressTrackerService.GetUserProgress(userId);
        }

    }
}
