using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using NepFit.Repository.Entity;
using NepFit.Repository.Repository.Interface;

namespace NepFit.Repository.Repository
{
    public class NutritionRepository : INutritionRepository
    {
        private readonly ISqlServerConnectionProvider _sqlServerConnectionProvider;

        public NutritionRepository(ISqlServerConnectionProvider sqlServerConnectionProvider)
        {
            _sqlServerConnectionProvider = sqlServerConnectionProvider;
        }

        public int Add(Nutrition input)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.Execute("INSERT INTO Nutrition  ([NutritionId] ,[MealOne] ,[MealTwo] ,[MealThree] ,[MealFour] ,[MealFive] " +
                                ",[MealSix]) 	" +
                                "VALUES	(@NutritionId ,@MealOne ,@MealTwo ,@MealThree ,@MealFour ,@MealFive ,@MealSix) ", input);

        }
    }
}
