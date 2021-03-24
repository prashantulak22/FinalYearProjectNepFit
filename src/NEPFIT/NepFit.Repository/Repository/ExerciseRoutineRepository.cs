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
                                ",[Active] ,[UpdatedBy] ,[CreatedBy] ,[DateUpdated] ,[DateCreated] )" +
                                "	VALUES" +
                                "	( @Name ,@Description ,@Repetition, @Duration, @ExerciseTypeId  " +
                                ",@Active ,@UpdatedBy ,@CreatedBy ,@DateUpdated ,@DateCreated )", input);
        }

        public ExerciseRoutine Update(ExerciseRoutine input)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            conn.Execute("	UPDATE ExerciseRoutine SET 	" +
                                "	[ExerciseRoutineId] = @ExerciseRoutineId ,		" +
                                "[Name] = @Name ,		[Description] = @Description ,	" +
                                "[Repetition] = @Repetition, [Duration] =@Duration , [ExerciseTypeId]=@ExerciseTypeId" +
                                "	[Active] = @Active ,		[UpdatedBy] = @UpdatedBy ,	" +
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
