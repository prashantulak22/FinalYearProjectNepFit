using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using NepFit.Repository.Entity;
using NepFit.Repository.Repository.Interface;

namespace NepFit.Repository.Repository
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly ISqlServerConnectionProvider _sqlServerConnectionProvider;

        public ExerciseRepository(ISqlServerConnectionProvider sqlServerConnectionProvider)
        {
            _sqlServerConnectionProvider = sqlServerConnectionProvider;
        }

        
        public int Add(Exercise input)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.Execute("");

        }
    }

    }

