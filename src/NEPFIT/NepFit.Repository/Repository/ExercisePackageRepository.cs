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
    }

}
