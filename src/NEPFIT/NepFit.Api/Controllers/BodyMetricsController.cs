using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NepFit.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NepFit.Api.Controllers
{
    [ApiController]
    public class BodyMetricsController : ControllerBase
    {
        [HttpPost]
        public void CollectBodyMetrics(BodyMetrics input)
        {

        }
    }
}
