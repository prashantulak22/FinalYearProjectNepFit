using AutoMapper;
using NepFit.Repository.Dto;
using NepFit.Repository.Entity;

namespace NepFit.Repository.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BodyMetricsCreateDto, BodyMetrics>().ReverseMap();
        }
    }
}
