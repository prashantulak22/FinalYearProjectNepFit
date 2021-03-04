using AutoMapper;
using NepFit.BL.Interface;
using NepFit.Repository.Dto;
using NepFit.Repository.Entity;
using NepFit.Repository.Repository.Interface;

namespace NepFit.BL
{
    public class ExercisePackageService : IExercisePackageService
    {
        private readonly IExercisePackageRepository _exercisePackageRepository;
        private readonly IMapper _mapper;

        public ExercisePackageService(IExercisePackageRepository exercisePackageRepository, IMapper mapper)
        {
            _exercisePackageRepository = exercisePackageRepository;
            _mapper = mapper;
        }

        public int AddExercisePackage(ExercisePackageCreateDto inputDto)
        {
            return _exercisePackageRepository.Add(_mapper.Map<ExercisePackage>(inputDto));
        }
    }
}
