using Dapper;
using NepFit.Repository.Entity;
using NepFit.Repository.Repository.Interface;

namespace NepFit.Repository.Repository
{
    public class BodyMetricsRepository : IBodyMetricsRepository
    {
        private readonly ISqlServerConnectionProvider _sqlServerConnectionProvider;

        public BodyMetricsRepository(ISqlServerConnectionProvider sqlServerConnectionProvider)
        {
            _sqlServerConnectionProvider = sqlServerConnectionProvider;
        }

        public int Add(BodyMetrics input)
        {
            var conn = _sqlServerConnectionProvider.GetDbConnection();
            return conn.Execute("INSERT INTO BodyMetrics  ([Height] ,[BodyMass] ,[ChestSize] ,[ArmSize] ,[ForearmSize] ,[WristSize] " +
                                ",[NeckSize] ,[UpperAbs] ,[LowerAbs] ,[HipSize] ,[WaistSize] ,[ThighSize] ,[CalveSize] ,[UserId] ) 	" +
                                "VALUES	(@Height ,@BodyMass ,@ChestSize ,@ArmSize ,@ForearmSize ,@WristSize ,@NeckSize ,@UpperAbs" +
                                " ,@LowerAbs ,@HipSize ,@WaistSize ,@ThighSize ,@CalveSize ,@UserId )", input);

        }
    }
}
