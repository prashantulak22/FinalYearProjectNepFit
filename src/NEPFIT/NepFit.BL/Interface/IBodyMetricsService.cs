using NepFit.Repository.Dto;

namespace NepFit.BL.Interface
{
    public interface IBodyMetricsService
    {
        int AddBodyMetrics(BodyMetricsCreateDto inputDto);
    }
}
