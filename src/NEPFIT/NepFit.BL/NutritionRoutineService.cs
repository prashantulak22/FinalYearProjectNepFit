using AutoMapper;
using NepFit.BL.Interface;
using NepFit.Repository.Dto;
using NepFit.Repository.Entity;
using NepFit.Repository.Repository.Interface;

namespace NepFit.BL
{
    public class NutritionRoutineService : INutritionRoutineService
    {
        private readonly INutritionRoutineRepository _nutritionRoutineRepository;
        private readonly IMapper _mapper;

        public NutritionRoutineService(INutritionRoutineRepository nutritionRoutineRepository, IMapper mapper)
        {
            _nutritionRoutineRepository = nutritionRoutineRepository;
            _mapper = mapper;
        }

        public int AddNutritionRoutine(NutritionRoutineCreateDto inputDto)
        {
            return _nutritionRoutineRepository.Add(_mapper.Map<NutritionRoutine>(inputDto));

        }
    }
}
