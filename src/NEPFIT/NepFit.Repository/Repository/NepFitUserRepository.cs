using System;
using System.Collections.Generic;
using Dapper;
using NepFit.Repository.Dto;
using NepFit.Repository.Entity;
using NepFit.Repository.Repository.Interface;

namespace NepFit.Repository.Repository
{
    public class NepFitUserRepository : INepFitUserRepository
    {
        private readonly ISqlServerConnectionProvider _sqlServerConnectionProvider;

        public NepFitUserRepository(ISqlServerConnectionProvider sqlServerConnectionProvider)
        {
            _sqlServerConnectionProvider = sqlServerConnectionProvider;
        }

        public int Add(NepFitUser input)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.Execute("INSERT INTO NepFitUser( [UserId],[FirstName] " +
                ",[LastName] ,[DateOfBirth] ,[Gender] ,[ExperienceLevel], [IsAdmin] ,[Active] " +
                ",[UpdatedBy] ,[CreatedBy] ,[DateUpdated] ,[DateCreated], [ExerciseNutritionPackageId] )VALUES	" +
                "( @CreatedBy, @FirstName ,@LastName ,@DateOfBirth ,@Gender, @ExperienceLevel ,@IsAdmin ,@Active " +
                ",@UpdatedBy ,@CreatedBy ,@DateUpdated ,@DateCreated, @ExerciseNutritionPackageId )", input);
        }

        public NepFitUser Update(NepFitUser input)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            conn.Execute("	UPDATE NepFitUser SET [UserId] = @UserId ,[FirstName] = @FirstName " +
                ",[LastName] = @LastName ,[DateOfBirth] = @DateOfBirth ,[Gender] = @Gender,[ExperienceLevel] = @ExperienceLevel , " +
                ",[IsAdmin] = @IsAdmin ,[Active] = @Active ,[UpdatedBy] = @UpdatedBy " +
                ",[CreatedBy] = @CreatedBy ,[DateUpdated] = @DateUpdated ,[DateCreated] = @DateCreated, [ExerciseNutritionPackageId] = @ExerciseNutritionPackageId " +
                " WHERE [UserId]=@UserId", input);
            return input;
        }

        public IEnumerable<NepFitUserResultDto> GetAll()
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.Query<NepFitUserResultDto>(
                "Select nfu.*,  np.Name NutritionPackageName From [dbo].[NepFitUser] nfu" +
                " JOIN [dbo].[ExerciseNutritionPackage] enp ON nfu.ExerciseNutritionPackageId = enp.ExerciseNutritionPackageId" +
                " JOIN [dbo].[NutritionPackage] np ON enp.NutritionPackageId = np.NutritionPackageId" +
                " WHERE nfu.Active = 1 AND enp.Active = 1 order by nfu.DateCreated");
        }

        public NepFitUser GetById(Guid id)
        {

            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.QueryFirstOrDefault<NepFitUser>(
                "Select * From [dbo].[NepFitUser] WHERE Active = 1 AND UserId = @NepFitUserId", new
                {
                    NepFitUserId = id
                });
        }

        public bool Delete(NepFitUser input)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            conn.Execute("	UPDATE NepFitUser SET 	" +
                         "	[Active] = 0 ,		[UpdatedBy] = @UpdatedBy ,	" +
                         "	[DateUpdated] = @DateUpdated		" +
                         " WHERE [UserId]=@UserId", input);
            return true;
        }
    }
}
