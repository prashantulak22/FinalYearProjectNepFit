using Dapper;
using NepFit.Repository.Entity;
using NepFit.Repository.Repository.Interface;
using System;
using System.Collections.Generic;

namespace NepFit.Repository.Repository
{
    public class ExercisePackageRoutineRepository : IExercisePackageRoutineRepository
    {
        private readonly ISqlServerConnectionProvider _sqlServerConnectionProvider;

        public ExercisePackageRoutineRepository(ISqlServerConnectionProvider sqlServerConnectionProvider)
        {
            _sqlServerConnectionProvider = sqlServerConnectionProvider;
        }

        public int Add(ExercisePackageRoutine input)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.Execute("INSERT INTO ExercisePackageRoutine ( [Name] ,[Description] " +
                                ",[Active] ,[UpdatedBy] ,[CreatedBy] ,[DateUpdated] ,[DateCreated] )" +
                                "	VALUES" +
                                "	( @Name ,@Description " +
                                ",@Active ,@UpdatedBy ,@CreatedBy ,@DateUpdated ,@DateCreated )", input);
        }

        public ExercisePackageRoutine Update(ExercisePackageRoutine input)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            conn.Execute("	UPDATE ExercisePackageRoutine SET 	" +
                                "	[ExercisePackageRoutineId] = @ExercisePackageRoutineId ,		" +
                                "[Name] = @Name ,		[Description] = @Description ,	" +
                                "	[Active] = @Active ,		[UpdatedBy] = @UpdatedBy ,	" +
                                "	[CreatedBy] = @CreatedBy ,		[DateUpdated] = @DateUpdated ,		" +
                                "[DateCreated] = @DateCreated 	WHERE [ExercisePackageRoutineId]=@ExercisePackageRoutineId", input);
            return input;
        }

        public IEnumerable<ExercisePackageRoutine> GetAll()
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.Query<ExercisePackageRoutine>(
                "Select * From [dbo].[ExercisePackageRoutine] WHERE Active = 1 order by DateCreated");
        }

        public ExercisePackageRoutine GetById(Guid id)
        {

            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.QueryFirstOrDefault<ExercisePackageRoutine>(
                "Select * From [dbo].[ExercisePackageRoutine] WHERE Active = 1 AND ExercisePackageRoutineId = @ExercisePackageRoutineId", new
                {
                    ExercisePackageRoutineId = id
                });
        }

        public bool Delete(ExercisePackageRoutine input)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            conn.Execute("	UPDATE ExercisePackageRoutine SET 	" +
                         "	[Active] = 0 ,		[UpdatedBy] = @UpdatedBy ,	" +
                         "	[DateUpdated] = @DateUpdated		" +
                         " WHERE [ExercisePackageRoutineId]=@ExercisePackageRoutineId", input);
            return true;
        }
    }
}
