using System;
using System.Collections.Generic;
using Dapper;
using NepFit.Repository.Entity;
using NepFit.Repository.Repository.Interface;

namespace NepFit.Repository.Repository
{
    public class ProgressTrackerRepository : IProgressTrackerRepository
    {
        private readonly ISqlServerConnectionProvider _sqlServerConnectionProvider;

        public ProgressTrackerRepository(ISqlServerConnectionProvider sqlServerConnectionProvider)
        {
            _sqlServerConnectionProvider = sqlServerConnectionProvider;
        }

        public IEnumerable<ProgressTracker> GetProgressByUser(Guid userId)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.Query<ProgressTracker>("Select * From [dbo].[ProgressTracker] WHERE UserId = @UserId", new
            {
                UserId = userId
            });
        }
    }
}