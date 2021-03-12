using System;
using System.Collections.Generic;
using Dapper;
using NepFit.Repository.Entity;
using NepFit.Repository.Repository.Interface;

namespace NepFit.Repository.Repository
{
    public class ExerciseRoutineRepository : IExerciseRoutineRepository
    {
        private readonly ISqlServerConnectionProvider _sqlServerConnectionProvider;

        public ExerciseRoutineRepository(ISqlServerConnectionProvider sqlServerConnectionProvider)
        {
            _sqlServerConnectionProvider = sqlServerConnectionProvider;
        }

        public int Add(ExerciseRoutine input)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.Execute("INSERT INTO ExerciseRoutine ( [Name] ,[Description] " +
                                ",[Active] ,[UpdatedBy] ,[CreatedBy] ,[DateUpdated] ,[DateCreated] )" +
                                "	VALUES" +
                                "	( @Name ,@Description " +
                                ",@Active ,@UpdatedBy ,@CreatedBy ,@DateUpdated ,@DateCreated )", input);
        }

        public ExerciseRoutine Update(ExerciseRoutine input)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            conn.Execute("	UPDATE ExerciseRoutine SET 	" +
                                "	[ExerciseRoutineId] = @ExerciseRoutineId ,		" +
                                "[Name] = @Name ,		[Description] = @Description ,	" +
                                "	[Active] = @Active ,		[UpdatedBy] = @UpdatedBy ,	" +
                                "	[CreatedBy] = @CreatedBy ,		[DateUpdated] = @DateUpdated ,		" +
                                "[DateCreated] = @DateCreated 	WHERE [ExerciseRoutineId]=@ExerciseRoutineId", input);
            return input;
        }

        public IEnumerable<ExerciseRoutine> GetAll()
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.Query<ExerciseRoutine>(
                "Select * From [dbo].[ExerciseRoutine] WHERE Active = 1 order by DateCreated");
        }

        public ExerciseRoutine GetById(Guid id)
        {

            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.QueryFirstOrDefault<ExerciseRoutine>(
                "Select * From [dbo].[ExerciseRoutine] WHERE Active = 1 AND ExerciseRoutineId = @ExerciseRoutineId", new
                {
                    ExerciseRoutineId = id
                });
        }

        public bool Delete(ExerciseRoutine input)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            conn.Execute("	UPDATE ExerciseRoutine SET 	" +
                         "	[Active] = 0 ,		[UpdatedBy] = @UpdatedBy ,	" +
                         "	[DateUpdated] = @DateUpdated		" +
                         " WHERE [ExerciseRoutineId]=@ExerciseRoutineId", input);
            return true;
        }
    }
}
