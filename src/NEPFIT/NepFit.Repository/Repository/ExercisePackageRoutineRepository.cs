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

        public int Add(Guid input)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.Execute("INSERT INTO ExercisePackageRoutine" +
                "([ExercisePackageId] ,[ExerciseRoutineId] " +
                ",[Active] ,[UpdatedBy] ,[CreatedBy] ,[DateUpdated] ,[DateCreated] )	VALUES" +
                "	(@ExercisePackageId ,@ExerciseRoutineId ,@Active " +
                ",@UpdatedBy ,@CreatedBy ,@DateUpdated ,@DateCreated))", input);
        }

        public int Update(Guid input)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.Execute("	UPDATE ExercisePackageRoutine SET " +
                "[ExercisePackageId] = @ExercisePackageId ," +
                "[ExerciseRoutineId] = @ExerciseRoutineId " +
                ",[Active] = @Active ,[UpdatedBy] = @UpdatedBy " +
                ",[CreatedBy] = @CreatedBy ,[DateUpdated] = @DateUpdated ," +
                "[DateCreated] = @DateCreated WHERE [NutritionPackageRoutineId]=@NutritionPackageRoutineId", input);
            
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
