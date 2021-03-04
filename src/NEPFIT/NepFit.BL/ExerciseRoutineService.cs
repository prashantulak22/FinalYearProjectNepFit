using AutoMapper;
using NepFit.BL.Interface;
using NepFit.Repository.Dto;
using NepFit.Repository.Entity;
using NepFit.Repository.Repository.Interface;

namespace NepFit.BL
{
    public class ExerciseRoutineService : IExerciseRoutineService
    {
        private readonly IExerciseRoutineRepository _exerciseRoutineRepository;
        private readonly IMapper _mapper;
        public ExerciseRoutineService(IExerciseRoutineRepository exerciseRoutineRepository, IMapper mapper)
        {
            _exerciseRoutineRepository = exerciseRoutineRepository;
            _mapper = mapper;

        }

        public int AddExerciseRoutine(ExerciseRoutineCreateDto inputDto)
        {
            return _exerciseRoutineRepository.Add(_mapper.Map<ExerciseRoutine>(inputDto));
        }
    }
}
