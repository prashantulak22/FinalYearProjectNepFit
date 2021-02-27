using System;
using System.Collections.Generic;
using NepFit.Repository.Dto;

namespace NepFit.BL.Interface
{
    public interface IProgressTrackerService
    {
        IEnumerable<ProgressTrackerChartResultDto> GetUserProgress(Guid userId);
    }
}

