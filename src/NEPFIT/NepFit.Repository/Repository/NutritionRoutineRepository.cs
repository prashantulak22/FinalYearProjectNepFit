using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
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
            return conn.Execute("INSERT INTO NutritionRoutine  ([Name] ,[Description] ,[HowToPrepare] ,[NutritionId] ,[NutritionPackageId] ) " +
                                "VALUES	(@Name ,@Description ,@HowToPrepare ,@NutritionId ,@NutritionPackageId) ", input);

        }
    }
}
