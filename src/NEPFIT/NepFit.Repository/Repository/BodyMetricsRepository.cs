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
            return conn.Execute("INSERT INTO BodyMetrics  ([Height] ,[BodyMass] ,[NeckSize] ,[ShoulderSize] ,[ChestSize] ,[UpperAbsSize] " +
                                ",[LowerAbsSize], [HipSize] ,[RightBicepSize] ,[LeftBicepSize] ,[ForeArmSize] ,[WaistSize] " +
                                ",[RightThighSize], [LeftThighSize], [RightCalveSize], [LeftCalveSize], [DateCreated] ,[UserId] ) 	" +

                                "VALUES	(@Height ,@BodyMass, @NeckSize, @ShoulderSize, @ChestSize, @UpperAbsSize, @LowerAbsSize, " +
                                " @HipSize, @RightBicepSize, @LeftBicepSize, @ForeArmSize, @WaistSize, @RightThighSize, @LeftThighSize, " +
                                "@RightCalveSize, @LeftCalveSize, @DateCreated, " +
                                " @UserId ) ", input);

        }
    }
}
