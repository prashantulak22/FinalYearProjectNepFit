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
            return conn.Execute("INSERT INTO NutritionPackageRoutine" +
                "([NutritionPackageId] ,[NutritionRoutineId] " +
                ",[Active] ,[UpdatedBy] ,[CreatedBy] ,[DateUpdated] ,[DateCreated] )	VALUES" +
                "	(@NutritionPackageId ,@NutritionRoutineId ,@Active " +
                ",@UpdatedBy ,@CreatedBy ,@DateUpdated ,@DateCreated)", input);
        }

        public int Update(NutritionPackageRoutine input)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.Execute("	UPDATE NutritionPackageRoutine SET " +
                "[NutritionPackageId] = @NutritionPackageId ," +
                "[NutritionRoutineId] = @NutritionRoutineId " +
                ",[Active] = @Active ,[UpdatedBy] = @UpdatedBy " +
                ",[CreatedBy] = @CreatedBy ,[DateUpdated] = @DateUpdated ," +
                "[DateCreated] = @DateCreated WHERE [NutritionPackageRoutineId]=@NutritionPackageRoutineId", input);


        }

        public IEnumerable<NutritionPackageRoutineResultDto> GetAll()
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.Query<NutritionPackageRoutineResultDto>(
                "Select npr.*, np.Name NutritionPackageName, nr.Name NutritionRoutineName, nt.Name NutritionTypeName From [dbo].[NutritionPackageRoutine] npr " +
                " INNER JOIN [dbo].[NutritionPackage] np ON npr.NutritionPackageId = np.NutritionPackageId " +
                " INNER JOIN [dbo].[NutritionRoutine] nr on npr.NutritionRoutineId = nr.NutritionRoutineId " +
                " INNER JOIN [dbo].[NutritionType] nt on nr.NutritionTypeId = nt.NutritionTypeId " +
                " WHERE nr.Active = 1 and np.Active = 1 and nt.Active =1 and npr.Active = 1 order by npr.DateCreated");
        }
        public IEnumerable<NutritionPackageRoutineResultDto> GetByNutritionPackageId(Guid id)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.Query<NutritionPackageRoutineResultDto>(
                "Select npr.*, np.Name NutritionPackageName, nr.Name NutritionRoutineName, nt.Name NutritionTypeName From [dbo].[NutritionPackageRoutine] npr " +
                " INNER JOIN [dbo].[NutritionPackage] np ON npr.NutritionPackageId = np.NutritionPackageId " +
                " INNER JOIN [dbo].[NutritionRoutine] nr on npr.NutritionRoutineId = nr.NutritionRoutineId " +
                " INNER JOIN [dbo].[NutritionType] nt on nr.NutritionTypeId = nt.NutritionTypeId " +
                " WHERE nr.Active = 1 and np.Active = 1 and nt.Active =1 and npr.Active = 1 order by npr.DateCreated and npr.NutritionPackageId = @NutritionPackageId", new
                {
                    NutritionPackageId = id
                });
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
