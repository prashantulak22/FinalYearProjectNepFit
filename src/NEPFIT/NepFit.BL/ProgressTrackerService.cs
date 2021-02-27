using System;
using System.Collections.Generic;
using AutoMapper;
using NepFit.BL.Interface;
using NepFit.Repository.Dto;
using NepFit.Repository.Repository.Interface;

namespace NepFit.BL
{
    public class ProgressTrackerService : IProgressTrackerService
    {
        private readonly IProgressTrackerRepository _progressTrackerRepository;
        private readonly IMapper _mapper;
        public ProgressTrackerService(IProgressTrackerRepository progressTrackerRepository, IMapper mapper)
        {
            _progressTrackerRepository = progressTrackerRepository;
            _mapper = mapper;
        }

        public IEnumerable<ProgressTrackerChartResultDto> GetUserProgress(Guid userId)
        {
            return
                _mapper.Map<IEnumerable<ProgressTrackerChartResultDto>>
                    (_progressTrackerRepository.GetProgressByUser(userId));
        }
    }
}