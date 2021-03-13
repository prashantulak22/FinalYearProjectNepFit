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

        public int Add(Guid input)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.Execute("INSERT INTO NutritionPackageRoutine" +
                "([NutritionPackageId] ,[NutritionRoutineId] " +
                ",[Active] ,[UpdatedBy] ,[CreatedBy] ,[DateUpdated] ,[DateCreated] )	VALUES" +
                "	(,@NutritionPackageId ,@NutritionRoutineId ,@Active " +
                ",@UpdatedBy ,@CreatedBy ,@DateUpdated ,@DateCreated)", input);
        }

        public int Update(Guid input)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.Execute("	UPDATE NutritionPackageRoutine SET " +
                "[NutritionPackageId] = @NutritionPackageId ," +
                "[NutritionRoutineId] = @NutritionRoutineId " +
                ",[Active] = @Active ,[UpdatedBy] = @UpdatedBy " +
                ",[CreatedBy] = @CreatedBy ,[DateUpdated] = @DateUpdated ," +
                "[DateCreated] = @DateCreated WHERE [NutritionPackageRoutineId]=@NutritionPackageRoutineId", input);

           
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
