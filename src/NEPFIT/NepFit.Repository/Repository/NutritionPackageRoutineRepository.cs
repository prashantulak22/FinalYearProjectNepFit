using Dapper;
using NepFit.Repository.Dto;
using NepFit.Repository.Repository.Interface;
using System;
using System.Collections.Generic;

namespace NepFit.Repository.Repository
{
    public class NutritionPackageRoutineRepository : INutritionPackageRoutineRepository
    {
        private readonly ISqlServerConnectionProvider _sqlServerConnectionProvider;

        public NutritionPackageRoutineRepository(ISqlServerConnectionProvider sqlServerConnectionProvider)
        {
            _sqlServerConnectionProvider = sqlServerConnectionProvider;
        }

        public int Add(NutritionPackageRoutine input)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.Execute("INSERT INTO NutritionPackageRoutine ( [Name] ,[Description] " +
                                ",[Active] ,[UpdatedBy] ,[CreatedBy] ,[DateUpdated] ,[DateCreated] )" +
                                "	VALUES" +
                                "	( @Name ,@Description " +
                                ",@Active ,@UpdatedBy ,@CreatedBy ,@DateUpdated ,@DateCreated )", input);
        }

        public NutritionPackageRoutine Update(NutritionPackageRoutine input)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            conn.Execute("	UPDATE NutritionPackageRoutine SET 	" +
                                "	[NutritionPackageRoutineId] = @NutritionPackageRoutineId ,		" +
                                "[Name] = @Name ,		[Description] = @Description ,	" +
                                "	[Active] = @Active ,		[UpdatedBy] = @UpdatedBy ,	" +
                                "	[CreatedBy] = @CreatedBy ,		[DateUpdated] = @DateUpdated ,		" +
                                "[DateCreated] = @DateCreated 	WHERE [NutritionPackageRoutineId]=@NutritionPackageRoutineId", input);
            return input;
        }

        public IEnumerable<NutritionPackageRoutine> GetAll()
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.Query<NutritionPackageRoutine>(
                "Select * From [dbo].[NutritionPackageRoutine] WHERE Active = 1 order by DateCreated");
        }

        public NutritionPackageRoutine GetById(Guid id)
        {

            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.QueryFirstOrDefault<NutritionPackageRoutine>(
                "Select * From [dbo].[NutritionPackageRoutine] WHERE Active = 1 AND NutritionPackageRoutineId = @NutritionPackageRoutineId", new
                {
                    NutritionPackageRoutineId = id
                });
        }

        public bool Delete(NutritionPackageRoutine input)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            conn.Execute("	UPDATE NutritionPackageRoutine SET 	" +
                         "	[Active] = 0 ,		[UpdatedBy] = @UpdatedBy ,	" +
                         "	[DateUpdated] = @DateUpdated		" +
                         " WHERE [NutritionPackageRoutineId]=@NutritionPackageRoutineId", input);
            return true;
        }
    }
}
