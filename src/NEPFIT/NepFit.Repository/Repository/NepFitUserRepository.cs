﻿using System;
using System.Collections.Generic;
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
            return conn.Execute("INSERT INTO NepFitUser ( [Name] ,[Description] " +
                                ",[Active] ,[UpdatedBy] ,[CreatedBy] ,[DateUpdated] ,[DateCreated] )" +
                                "	VALUES" +
                                "	( @Name ,@Description " +
                                ",@Active ,@UpdatedBy ,@CreatedBy ,@DateUpdated ,@DateCreated )", input);
        }

        public NepFitUser Update(NepFitUser input)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            conn.Execute("	UPDATE NepFitUser SET 	" +
                                "	[NepFitUserId] = @NepFitUserId ,		" +
                                "[Name] = @Name ,		[Description] = @Description ,	" +
                                "	[Active] = @Active ,		[UpdatedBy] = @UpdatedBy ,	" +
                                "	[CreatedBy] = @CreatedBy ,		[DateUpdated] = @DateUpdated ,		" +
                                "[DateCreated] = @DateCreated 	WHERE [NepFitUserId]=@NepFitUserId", input);
            return input;
        }

        public IEnumerable<NepFitUser> GetAll()
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.Query<NepFitUser>(
                "Select * From [dbo].[NepFitUser] WHERE Active = 1 order by DateCreated");
        }

        public NepFitUser GetById(Guid id)
        {

            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.QueryFirstOrDefault<NepFitUser>(
                "Select * From [dbo].[NepFitUser] WHERE Active = 1 AND NepFitUserId = @NepFitUserId", new
                {
                    NepFitUserId = id
                });
        }

        public bool Delete(NepFitUser input)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            conn.Execute("	UPDATE NepFitUser SET 	" +
                         "	[Active] = 0 ,		[UpdatedBy] = @UpdatedBy ,	" +
                         "	[DateUpdated] = @DateUpdated		" +
                         " WHERE [NepFitUserId]=@NepFitUserId", input);
            return true;
        }
    }
}
