using AutoMapper;
using NepFit.BL.Interface;
using NepFit.Repository.Dto;
using NepFit.Repository.Entity;
using NepFit.Repository.Repository.Interface;

namespace NepFit.BL
{
    public class BodyMetricsService : IBodyMetricsService
    {
        private readonly IBodyMetricsRepository _bodyMetricsRepository;
        private readonly IMapper _mapper;
        public BodyMetricsService(IBodyMetricsRepository bodyMetricsRepository, IMapper mapper)
        {
            _bodyMetricsRepository = bodyMetricsRepository;
            _mapper = mapper;
        }

        public int AddBodyMetrics(BodyMetricsCreateDto inputDto)
        {
            return _bodyMetricsRepository.Add(_mapper.Map<BodyMetrics>(inputDto));
        }
    }
}