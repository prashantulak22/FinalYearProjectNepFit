using System;
using System.Collections.Generic;
using Dapper;
using NepFit.Repository.Entity;
using NepFit.Repository.Repository.Interface;

namespace NepFit.Repository.Repository
{
    public class NutritionPackageRepository : INutritionPackageRepository
    {
        private readonly ISqlServerConnectionProvider _sqlServerConnectionProvider;

        public NutritionPackageRepository(ISqlServerConnectionProvider sqlServerConnectionProvider)
        {
            _sqlServerConnectionProvider = sqlServerConnectionProvider;
        }

        public int Add(NutritionPackage input)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.Execute("INSERT INTO NutritionPackage ( [Name] ,[Description] " +
                                ",[Active] ,[UpdatedBy] ,[CreatedBy] ,[DateUpdated] ,[DateCreated] )" +
                                "	VALUES" +
                                "	( @Name ,@Description " +
                                ",@Active ,@UpdatedBy ,@CreatedBy ,@DateUpdated ,@DateCreated )", input);
        }

        public NutritionPackage Update(NutritionPackage input)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            conn.Execute("	UPDATE NutritionPackage SET 	" +
                                "	[NutritionPackageId] = @NutritionPackageId ,		" +
                                "[Name] = @Name ,		[Description] = @Description ,	" +
                                "	[Active] = @Active ,		[UpdatedBy] = @UpdatedBy ,	" +
                                "	[CreatedBy] = @CreatedBy ,		[DateUpdated] = @DateUpdated ,		" +
                                "[DateCreated] = @DateCreated 	WHERE [NutritionPackageId]=@NutritionPackageId", input);
            return input;
        }

        public IEnumerable<NutritionPackage> GetAll()
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.Query<NutritionPackage>(
                "Select * From [dbo].[NutritionPackage] WHERE Active = 1 order by DateCreated");
        }

        public NutritionPackage GetById(Guid id)
        {

            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.QueryFirstOrDefault<NutritionPackage>(
                "Select * From [dbo].[NutritionPackage] WHERE Active = 1 AND NutritionPackageId = @NutritionPackageId", new
                {
                    NutritionPackageId = id
                });
        }

        public bool Delete(NutritionPackage input)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            conn.Execute("	UPDATE NutritionPackage SET 	" +
                         "	[Active] = 0 ,		[UpdatedBy] = @UpdatedBy ,	" +
                         "	[DateUpdated] = @DateUpdated		" +
                         " WHERE [NutritionPackageId]=@NutritionPackageId", input);
            return true;
        }
    }
}
