using System;
using System.Collections.Generic;
using Dapper;
using NepFit.Repository.Dto;
using NepFit.Repository.Entity;
using NepFit.Repository.Repository.Interface;

namespace NepFit.Repository.Repository
{ 
    public class ExerciseNutritionPackageRepository : IExerciseNutritionPackageRepository
    {
        private readonly ISqlServerConnectionProvider _sqlServerConnectionProvider;

        public ExerciseNutritionPackageRepository(ISqlServerConnectionProvider sqlServerConnectionProvider)
        {
            _sqlServerConnectionProvider = sqlServerConnectionProvider;
        }

        public int Add(ExerciseNutritionPackage input)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.Execute("INSERT INTO ExerciseNutritionPackage ( [ExercisePackageId] ,[NutritionPackageId] " +
                                ",[Active] ,[UpdatedBy] ,[CreatedBy] ,[DateUpdated] ,[DateCreated] )" +
                                "	VALUES" +
                                "	( @ExercisePackageId ,@NutritionPackageId " +
                                ",@Active ,@UpdatedBy ,@CreatedBy ,@DateUpdated ,@DateCreated )", input);
        }

        public ExerciseNutritionPackage Update(ExerciseNutritionPackage input)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            conn.Execute("	UPDATE ExerciseNutritionPackage SET 	" +                               
                                "[ExercisePackageId] = @ExercisePackageId ,		[NutritionPackageId] = @NutritionPackageId ,	" +
                                "	[Active] = @Active ,		[UpdatedBy] = @UpdatedBy ,	" +
                                "	[CreatedBy] = @CreatedBy ,		[DateUpdated] = @DateUpdated ,		" +
                                "[DateCreated] = @DateCreated 	WHERE [ExerciseNutritionPackageId] = @ExerciseNutritionPackageId", input);
            return input;
        }

        public IEnumerable<ExerciseNutritionPackageResultDto> GetAll()
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.Query<ExerciseNutritionPackageResultDto>(
                "Select enp.*, ep.Name ExercisePackageName, np.Name NutritionPackageName From [dbo].[ExerciseNutritionPackage] enp" +
                " INNER JOIN [dbo].[ExercisePackage] ep ON enp.ExercisePackageId = ep.ExercisePackageId " +
                " INNER JOIN [dbo].[NutritionPackage] np ON enp.NutritionPackageId = np.NutritionPackageId " +
                " WHERE np.Active = 1 and ep.Active = 1 and enp.Active = 1 order by enp.DateCreated");
        }

        public ExerciseNutritionPackage GetById(Guid id)
        {

            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.QueryFirstOrDefault<ExerciseNutritionPackage>(
                "Select * From [dbo].[ExerciseNutritionPackage] WHERE Active = 1 ANDExerciseNutritionPackageId = @ExerciseNutritionPackageId", new
                {
                   ExerciseNutritionPackageId = id
                });
        }

        public bool Delete(ExerciseNutritionPackage input)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            conn.Execute("	UPDATE ExerciseNutritionPackage SET 	" +
                         "	[Active] = 0 ,		[UpdatedBy] = @UpdatedBy ,	" +
                         "	[DateUpdated] = @DateUpdated		" +
                         " WHERE [ExerciseNutritionPackageId]=@ExerciseNutritionPackageId", input);
            return true;
        }
    }
}
