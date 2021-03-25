using Dapper;
using NepFit.Repository.Dto;
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
            return conn.Execute("INSERT INTO ExercisePackageRoutine" +
                "([ExercisePackageId] ,[ExerciseRoutineId] " +
                ",[Active] ,[UpdatedBy] ,[CreatedBy] ,[DateUpdated] ,[DateCreated] )	VALUES" +
                "	(@ExercisePackageId ,@ExerciseRoutineId ,@Active " +
                ",@UpdatedBy ,@CreatedBy ,@DateUpdated ,@DateCreated)", input);
        }

        public int Update(ExercisePackageRoutine input)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.Execute("	UPDATE ExercisePackageRoutine SET " +
                "[ExercisePackageId] = @ExercisePackageId ," +
                "[ExerciseRoutineId] = @ExerciseRoutineId " +
                ",[Active] = @Active ,[UpdatedBy] = @UpdatedBy " +
                ",[CreatedBy] = @CreatedBy ,[DateUpdated] = @DateUpdated ," +
                "[DateCreated] = @DateCreated WHERE [NutritionPackageRoutineId]=@NutritionPackageRoutineId", input);
            
        }

        public IEnumerable<ExercisePackageRoutineResultDto> GetAll()
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.Query<ExercisePackageRoutineResultDto>(
                "Select epr.*, ep.Name ExercisePackageName, er.Name ExerciseRoutineName From [dbo].[ExercisePackageRoutine] epr" +
                " INNER JOIN [dbo].[ExercisePackage] ep ON epr.ExercisePackageId = ep.ExercisePackageId "+
                " INNER JOIN [dbo].[ExerciseRoutine] er ON epr.ExerciseRoutineId = er.ExerciseRoutineId "+
                " WHERE er.Active = 1 and ep.Active = 1 and epr.Active = 1 order by epr.DateCreated ");
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
