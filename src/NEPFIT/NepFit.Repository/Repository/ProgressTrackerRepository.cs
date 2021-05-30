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

        public IEnumerable<BodyMetrics> GetProgressByUser(Guid userId)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.Query<BodyMetrics>("Select * From [dbo].[BodyMetrics] WHERE UserId = @UserId order by DateCreated", new
            {
                UserId = userId
            });
        }
    }
}