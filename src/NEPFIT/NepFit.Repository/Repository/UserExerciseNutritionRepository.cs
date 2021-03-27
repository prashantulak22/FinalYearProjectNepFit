using System;
using System.Collections.Generic;
using Dapper;
using NepFit.Repository.Entity;
using NepFit.Repository.Repository.Interface;

namespace NepFit.Repository.Repository
{
    public class UserExerciseNutritionRepository : IUserExerciseNutritionRepository
    {
        private readonly ISqlServerConnectionProvider _sqlServerConnectionProvider;

        public UserExerciseNutritionRepository(ISqlServerConnectionProvider sqlServerConnectionProvider)
        {
            _sqlServerConnectionProvider = sqlServerConnectionProvider;
        }

        public int Add(UserExerciseNutrition input)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.Execute("INSERT INTO UserExerciseNutrition ( [Name] ,[Description] " +
                                ",[Active] ,[UpdatedBy] ,[CreatedBy] ,[DateUpdated] ,[DateCreated] )" +
                                "	VALUES" +
                                "	( @Name ,@Description " +
                                ",@Active ,@UpdatedBy ,@CreatedBy ,@DateUpdated ,@DateCreated )", input);
        }

        public UserExerciseNutrition Update(UserExerciseNutrition input)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            conn.Execute("	UPDATE UserExerciseNutrition SET 	" +
                                "	[UserExerciseNutritionId] = @UserExerciseNutritionId ,		" +
                                "[Name] = @Name ,		[Description] = @Description ,	" +
                                "	[Active] = @Active ,		[UpdatedBy] = @UpdatedBy ,	" +
                                "	[CreatedBy] = @CreatedBy ,		[DateUpdated] = @DateUpdated ,		" +
                                "[DateCreated] = @DateCreated 	WHERE [UserExerciseNutritionId]=@UserExerciseNutritionId", input);
            return input;
        }

        public IEnumerable<UserExerciseNutrition> GetAll()
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.Query<UserExerciseNutrition>(
                "Select * From [dbo].[UserExerciseNutrition] WHERE Active = 1 order by DateCreated");
        }

        public UserExerciseNutrition GetById(Guid id)
        {

            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.QueryFirstOrDefault<UserExerciseNutrition>(
                "Select * From [dbo].[UserExerciseNutrition] WHERE Active = 1 AND UserExerciseNutritionId = @UserExerciseNutritionId", new
                {
                    UserExerciseNutritionId = id
                });
        }

        public bool Delete(UserExerciseNutrition input)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            conn.Execute("	UPDATE UserExerciseNutrition SET 	" +
                         "	[Active] = 0 ,		[UpdatedBy] = @UpdatedBy ,	" +
                         "	[DateUpdated] = @DateUpdated		" +
                         " WHERE [UserExerciseNutritionId]=@UserExerciseNutritionId", input);
            return true;
        }
    }
}
