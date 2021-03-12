using Dapper;
using NepFit.Repository.Entity;
using NepFit.Repository.Repository.Interface;
using System;
using System.Collections.Generic;


namespace NepFit.Repository.Repository
{
    public class NutritionTypeRepository : INutritionTypeRepository
    {
        private readonly ISqlServerConnectionProvider _sqlServerConnectionProvider;

        public NutritionTypeRepository(ISqlServerConnectionProvider sqlServerConnectionProvider)
        {
            _sqlServerConnectionProvider = sqlServerConnectionProvider;
        }

        public int Add(NutritionType input)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.Execute("INSERT INTO NutritionType ( [Name] ,[Description] " +
                                ",[Active] ,[UpdatedBy] ,[CreatedBy] ,[DateUpdated] ,[DateCreated] )" +
                                "	VALUES" +
                                "	( @Name ,@Description " +
                                ",@Active ,@UpdatedBy ,@CreatedBy ,@DateUpdated ,@DateCreated )", input);
        }

        public bool Delete(NutritionType input)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            conn.Execute("	UPDATE NutritionType SET 	" +
                         "	[Active] = 0 ,		[UpdatedBy] = @UpdatedBy ,	" +
                         "	[DateUpdated] = @DateUpdated		" +
                         " WHERE [NutritionTypeId]=@NutritionTypeId", input);
            return true;
        }

        public IEnumerable<NutritionType> GetAll()
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.Query<NutritionType>(
                "Select * From [dbo].[NutritionType] WHERE Active = 1 order by DateCreated");
        }

        public NutritionType GetById(Guid id)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.QueryFirstOrDefault<NutritionType>(
                "Select * From [dbo].[NutritionType] WHERE Active = 1 AND NutritionTypeId = @NutritionTypeId", new
                {
                    NutritionTypeId = id
                });
        }

        public NutritionType Update(NutritionType input)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            conn.Execute("	UPDATE NutritionType SET 	" +
                                "	[NutritionTypeId] = @NutritionTypeId ,		" +
                                "[Name] = @Name ,		[Description] = @Description ,	" +
                                "	[Active] = @Active ,		[UpdatedBy] = @UpdatedBy ,	" +
                                "	[CreatedBy] = @CreatedBy ,		[DateUpdated] = @DateUpdated ,		" +
                                "[DateCreated] = @DateCreated 	WHERE [NutritionTypeId]=@NutritionTypeId", input);
            return input;
        }
    }
}