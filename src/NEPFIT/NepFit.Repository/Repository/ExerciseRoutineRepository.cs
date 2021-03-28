using System;
using System.Collections.Generic;
using Dapper;
using NepFit.Repository.Dto;
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
            return conn.Execute("INSERT INTO ExerciseRoutine ( [Name] ,[Description], [Repetition], [Duration], [ExerciseTypeId]" +
                                ",[Active] ,[UpdatedBy] ,[CreatedBy] ,[DateUpdated] ,[DateCreated], [Gender] )" +
                                "	VALUES" +
                                "	( @Name ,@Description ,@Repetition, @Duration, @ExerciseTypeId  " +
                                ",@Active ,@UpdatedBy ,@CreatedBy ,@DateUpdated ,@DateCreated , @Gender)", input);
        }

        public ExerciseRoutine Update(ExerciseRoutine input)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            conn.Execute("	UPDATE ExerciseRoutine SET 	" +
                                "	[ExerciseRoutineId] = @ExerciseRoutineId ,		" +
                                "	[Gender] = @Gender ,		" +
                                "[Name] = @Name ,		[Description] = @Description ,	" +
                                "[Repetition] = @Repetition, [Duration] =@Duration , [ExerciseTypeId]=@ExerciseTypeId" +
                                "	,[Active] = @Active ,		[UpdatedBy] = @UpdatedBy ,	" +
                                "	[CreatedBy] = @CreatedBy ,		[DateUpdated] = @DateUpdated ,		" +
                                "[DateCreated] = @DateCreated 	WHERE [ExerciseRoutineId]=@ExerciseRoutineId", input);
            return input;
        }

        public IEnumerable<ExerciseRoutineResultDto> GetAll()
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.Query<ExerciseRoutineResultDto>(
                "Select er.*, et.Name ExerciseTypeName  From [dbo].[ExerciseRoutine] er" +
                " INNER JOIN [dbo].[ExerciseType] et ON er.ExerciseTypeId = et.ExerciseTypeId " +
                "  WHERE er.Active = 1 and et.Active = 1 order by er.DateCreated");
        }

        public IEnumerable<ExerciseRoutineResultDto> GetByUserId(Guid id)
        {

            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.Query<ExerciseRoutineResultDto>(
                "Select et.Name ExerciseTypeName, ep.Name ExercisePackageName, er.* from NepFitUser nfu" +
                " INNER JOIN ExerciseNutritionPackage enp on nfu.ExerciseNutritionPackageId = enp.ExerciseNutritionPackageId " +
                "INNER JOIN ExercisePackageRoutine epr on enp.ExercisePackageId = epr.ExercisePackageId " +
                "INNER JOIN ExercisePackage ep on epr.ExercisePackageId = ep.ExercisePackageId " +
                "INNER JOIN ExerciseRoutine er on epr.ExerciseRoutineId = er.ExerciseRoutineId and nfu.Gender = er.Gender " +
                "INNER JOIN ExerciseType et on er.ExerciseTypeId = et.ExerciseTypeId " +
                "where nfu.Active =1 and nfu.UserId =@UserId" +
                " and enp.Active =1 and epr.Active =1  and er.Active =1  and et.Active =1 ", new
                {
                    UserId = id
                });
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
