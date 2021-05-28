using System;
using System.Collections.Generic;
using Dapper;
using NepFit.Repository.Dto;
using NepFit.Repository.Entity;
using NepFit.Repository.Repository.Interface;

namespace NepFit.Repository.Repository
{
    public class UserNotesRepository : IUserNotesRepository
    {
        private readonly ISqlServerConnectionProvider _sqlServerConnectionProvider;

        public UserNotesRepository(ISqlServerConnectionProvider sqlServerConnectionProvider)
        {
            _sqlServerConnectionProvider = sqlServerConnectionProvider;
        }

        public int Add(UserNotes input)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.Execute("INSERT INTO UserNotes ( [Notes] " +
                                ",[Active] ,[UpdatedBy] ,[CreatedBy] ,[DateUpdated] ,[DateCreated] , [UserId])" +
                                "	VALUES" +
                                "	( @Notes" +
                                ",@Active ,@UpdatedBy ,@CreatedBy ,@DateUpdated ,@DateCreated ,@UserId)", input);
        }

        public UserNotes Update(UserNotes input)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            conn.Execute("	UPDATE UserNotes SET 	" +
                                "	[UserNotesId] = @UserNotesId ,		" +
                                "[Notes] = @Notes ,	" +
                                "	[Active] = @Active ,		[UpdatedBy] = @UpdatedBy ,	" +
                                "	[CreatedBy] = @CreatedBy ,		[DateUpdated] = @DateUpdated ,		" +
                                "[DateCreated] = @DateCreated, [UserId] = @UserId 	WHERE [UserNotesId]=@UserNotesId", input);
            return input;
        }

        public IEnumerable<UserNotesResultDto> GetAll()
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.Query<UserNotesResultDto>(
                "Select * From [dbo].[UserNotes] WHERE Active = 1 order by DateCreated");
        }

        public UserNotes GetById(Guid id)
        {

            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.QueryFirstOrDefault<UserNotes>(
                "Select * From [dbo].[UserNotes] WHERE Active = 1 AND UserNotesId = @UserNotesId", new
                {
                    UserNotesId = id
                });
        }

        public IEnumerable<UserNotes> GetByUserId(Guid id)
        {

            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.Query<UserNotes>(
                "Select * From [dbo].[UserNotes] WHERE Active = 1 AND UserId = @UserId", new
                {
                    UserId = id
                });
        }


        public bool Delete(UserNotes input)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            conn.Execute("	UPDATE UserNotes SET 	" +
                         "	[Active] = 0 ,		[UpdatedBy] = @UpdatedBy ,	" +
                         "	[DateUpdated] = @DateUpdated		" +
                         " WHERE [UserNotesId]=@UserNotesId", input);
            return true;
        }
    }
}
