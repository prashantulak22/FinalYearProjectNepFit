using System.Data;

namespace NepFit.Repository
{
    public interface ISqlServerConnectionProvider
    {
        IDbConnection GetDbConnection();
    }
}