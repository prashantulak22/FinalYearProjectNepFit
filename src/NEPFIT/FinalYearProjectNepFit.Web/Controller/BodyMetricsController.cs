using Microsoft.AspNetCore.Mvc;
using NepFit.BL.Interface;
using NepFit.Repository.Dto;

namespace FinalYearProjectNepFit.Web.Controller
{
    [ApiController]
    public class BodyMetricsController: ControllerBase
    {
        private readonly IBodyMetricsService _bodyMetricsService;

        public BodyMetricsController(IBodyMetricsService bodyMetricsService)
        {
            _bodyMetricsService = bodyMetricsService;
        }

        [Route("api/bodymetrics/add")]
        [HttpPost]
        public ActionResult<int> SaveUser(BodyMetricsCreateDto input)
        {

            if (TryValidateModel(input))
            {
                return _bodyMetricsService.AddBodyMetrics(input);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

    }
}
