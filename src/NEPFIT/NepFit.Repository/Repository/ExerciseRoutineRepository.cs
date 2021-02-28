using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using NepFit.Repository.Entity;
using NepFit.Repository.Repository.Interface;

namespace NepFit.Repository.Repository
{

    public class ExerciseRoutineRepository : IExerciseRoutineRepository
    {
        private readonly ISqlServerConnectionProvider _sqlServerConnectionProvider;

        public ExerciseRoutineRepository(ISqlServerConnectionProvider sqlServerConnectionProvider)
        {
            _sqlServerConnectionProvider = sqlServerConnectionProvider;
        }

        public int Add(ExerciseRoutine input)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.Execute("INSERT INTO ExerciseRoutine  ([ExerciseRoutineId] ,[Name] ,[Description] ,[Repitition] ,[Sequence] ,[Duration] " +
                                ",[ExerciseId] ,[ExercisePackageId])" +
                                "VALUES	(@ExerciseRoutineId ,@Name ,@Description ,@Repitition ,@Sequence ,@Duration ,@ExerciseId " +
                                " ,@ExercisePackageId ) ", input);

        }
    }
}
