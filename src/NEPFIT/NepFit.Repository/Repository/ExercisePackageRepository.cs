using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using NepFit.Repository.Entity;
using NepFit.Repository.Repository.Interface;

namespace NepFit.Repository.Repository
{
    public class ExercisePackageRepository : IExercisePackageRepository
    {
        private readonly ISqlServerConnectionProvider _sqlServerConnectionProvider;

        public ExercisePackageRepository(ISqlServerConnectionProvider sqlServerConnectionProvider)
        {
            _sqlServerConnectionProvider = sqlServerConnectionProvider;
        }

        public int Add(ExercisePackage input)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.Execute("INSERT INTO ExercisePackage  ([ExercisePackageId] ,[Name] ,[Description] ) " +
                                "VALUES	(@ExercisePackageId ,@Name," +
                                " ,@Description ) ", input);

        }

        public ExercisePackage Update(ExercisePackage input)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            conn.Execute("UPDATE ExercisePackage SET[ExercisePackageId] = @ExercisePackageId," +
                "[Name] = @Name,[Description] = @Description,[Active] = @Active," +
                "[UpdatedBy] = @UpdatedBy,[CreatedBy] = @CreatedBy,[DateUpdated] = @DateUpdated," +
                "[DateCreated] = @DateCreated WHERE[ExercisePackageId] = @ExercisePackageId", input);
            return input;

        }

        public IEnumerable<ExercisePackage> GetAll(){
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.Query<ExercisePackage>(
                "Select * From [dbo].[ExercisePackage] WHERE Active = 1 order by DateCreated");

        }

        public ExercisePackage GetById(Guid id)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.QueryFirstOrDefault<ExercisePackage>(
                "Select * From [dbo].[ExercisePackage] WHERE Active = 1 AND ExercisePackageId = @ExercisePackageId", new
                {
                    ExercisePackageId = id
                });

        }

        public bool Delete(ExercisePackage input)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            conn.Execute("	UPDATE ExercisePackage SET 	" +
                         "	[Active] = 0 ,		[UpdatedBy] = @UpdatedBy ,	" +
                         "	[DateUpdated] = @DateUpdated ,		" +
                         " WHERE [ExercisePackageId]=@ExercisePackageId", input);
            return true;

        }




    }

}
