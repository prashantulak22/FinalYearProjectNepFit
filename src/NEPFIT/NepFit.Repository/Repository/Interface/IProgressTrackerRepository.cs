using System;
using System.Collections.Generic;
using NepFit.Repository.Entity;

namespace NepFit.Repository.Repository.Interface
{
    public interface IProgressTrackerRepository
    {
        IEnumerable<ProgressTracker> GetProgressByUser(Guid userId);
    }
}
