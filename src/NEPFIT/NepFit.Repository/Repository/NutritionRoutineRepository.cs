using System;
using System.Collections.Generic;
using Dapper;
using NepFit.Repository.Dto;
using NepFit.Repository.Entity;
using NepFit.Repository.Repository.Interface;

namespace NepFit.Repository.Repository
{
    public class NutritionRoutineRepository : INutritionRoutineRepository
    {
        private readonly ISqlServerConnectionProvider _sqlServerConnectionProvider;

        public NutritionRoutineRepository(ISqlServerConnectionProvider sqlServerConnectionProvider)
        {
            _sqlServerConnectionProvider = sqlServerConnectionProvider;
        }

        public int Add(NutritionRoutine input)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.Execute("INSERT INTO NutritionRoutine ( [Name] ,[Description] ,[HowToPrepare], [NutritionTypeId]" +
                                ",[Active] ,[UpdatedBy] ,[CreatedBy] ,[DateUpdated] ,[DateCreated] )" +
                                "	VALUES" +
                                "	( @Name ,@Description, @HowToPrepare, @NutritionTypeId" +
                                ",@Active ,@UpdatedBy ,@CreatedBy ,@DateUpdated ,@DateCreated )", input);
        }

        public NutritionRoutine Update(NutritionRoutine input)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            conn.Execute("	UPDATE NutritionRoutine SET 	" +
                                "	[NutritionRoutineId] = @NutritionRoutineId ,		" +
                                "[Name] = @Name ,		[Description] = @Description ,	" +
                                "[HowToPrepare] = @HowToPrepare, [NutritionTypeId] = @NutritionTypeId" +
                                "	,[Active] = @Active ,		[UpdatedBy] = @UpdatedBy ,	" +
                                "	[CreatedBy] = @CreatedBy ,		[DateUpdated] = @DateUpdated ,		" +
                                "[DateCreated] = @DateCreated 	WHERE [NutritionRoutineId]=@NutritionRoutineId", input);
            return input;
        }

        public IEnumerable<NutritionRoutineResultDto> GetAll()
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.Query<NutritionRoutineResultDto>(
                "Select nr.*, nt.Name NutritionTypeName From [dbo].[NutritionRoutine] nr" +
                " INNER JOIN [dbo].[NutritionType] nt ON nr.NutritionTypeId = nt.NutritionTypeId " +
                " WHERE nr.Active = 1  and nt.Active = 1 order by nr.DateCreated");
        }

        public NutritionRoutine GetById(Guid id)
        {

            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.QueryFirstOrDefault<NutritionRoutine>(
                "Select * From [dbo].[NutritionRoutine] WHERE Active = 1 AND NutritionRoutineId = @NutritionRoutineId", new
                {
                    NutritionRoutineId = id
                });
        }

        public bool Delete(NutritionRoutine input)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            conn.Execute("	UPDATE NutritionRoutine SET 	" +
                         "	[Active] = 0 ,		[UpdatedBy] = @UpdatedBy ,	" +
                         "	[DateUpdated] = @DateUpdated		" +
                         " WHERE [NutritionRoutineId]=@NutritionRoutineId", input);
            return true;
        }
    }
}
