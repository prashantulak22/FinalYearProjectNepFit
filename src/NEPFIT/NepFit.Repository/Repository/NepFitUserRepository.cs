using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using NepFit.Repository.Entity;
using NepFit.Repository.Repository.Interface;

namespace NepFit.Repository.Repository
{
    public class NepFitUserRepository : INepFitUserRepository
    {
        private readonly ISqlServerConnectionProvider _sqlServerConnectionProvider;

        public NepFitUserRepository(ISqlServerConnectionProvider sqlServerConnectionProvider)
        {
            _sqlServerConnectionProvider = sqlServerConnectionProvider;
        }

        public int Add(NepFitUser input)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.Execute("INSERT INTO NepFitUser  ([UserId] ,[FirstName] ,[LastName] ,[DateOfBirth] ,[Gender] ,[MobileNumber] )" +
                                "VALUES	(@UserId ,@FirstName ,@LastName ,@DateOfBirth ,@Gender ,@MobileNumber)", input);

        }
    }
}
