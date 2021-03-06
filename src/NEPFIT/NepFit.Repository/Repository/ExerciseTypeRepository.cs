using System;
using System.Collections.Generic;
using Dapper;
using NepFit.Repository.Entity;
using NepFit.Repository.Repository.Interface;

namespace NepFit.Repository.Repository
{
    public class ExerciseTypeRepository : IExerciseTypeRepository
    {
        private readonly ISqlServerConnectionProvider _sqlServerConnectionProvider;

        public ExerciseTypeRepository(ISqlServerConnectionProvider sqlServerConnectionProvider)
        {
            _sqlServerConnectionProvider = sqlServerConnectionProvider;
        }

        public int Add(ExerciseType input)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.Execute("INSERT INTO ExerciseType ([ExerciseTypeId] ,[Name] ,[Description] " +
                                ",[Active] ,[UpdatedBy] ,[CreatedBy] ,[DateUpdated] ,[DateCreated] )" +
                                "	VALUES" +
                                "	(@ExerciseTypeId ,@Name ,@Description " +
                                ",@Active ,@UpdatedBy ,@CreatedBy ,@DateUpdated ,@DateCreated )", input);
        }

        public ExerciseType Update(ExerciseType input)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            conn.Execute("	UPDATE ExerciseType SET 	" +
                                "	[ExerciseTypeId] = @ExerciseTypeId ,		" +
                                "[Name] = @Name ,		[Description] = @Description ,	" +
                                "	[Active] = @Active ,		[UpdatedBy] = @UpdatedBy ,	" +
                                "	[CreatedBy] = @CreatedBy ,		[DateUpdated] = @DateUpdated ,		" +
                                "[DateCreated] = @DateCreated 	WHERE [ExerciseTypeId]=@ExerciseTypeId", input);
            return input;
        }

        public IEnumerable<ExerciseType> GetAll()
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.Query<ExerciseType>(
                "Select * From [dbo].[ExerciseType] WHERE Active = 1 order by DateCreated");
        }

        public ExerciseType GetById(Guid id)
        {

            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.QueryFirstOrDefault<ExerciseType>(
                "Select * From [dbo].[ExerciseType] WHERE Active = 1 AND ExerciseTypeId = @ExerciseTypeId", new
                {
                    ExerciseTypeId = id
                });
        }

        public bool Delete(ExerciseType input)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            conn.Execute("	UPDATE ExerciseType SET 	" +
                         "	[Active] = 0 ,		[UpdatedBy] = @UpdatedBy ,	" +
                         "	[DateUpdated] = @DateUpdated ,		" +
                         " WHERE [ExerciseTypeId]=@ExerciseTypeId", input);
            return true;
        }
    }
}
