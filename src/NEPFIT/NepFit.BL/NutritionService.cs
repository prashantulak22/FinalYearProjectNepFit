using AutoMapper;
using NepFit.BL.Interface;
using NepFit.Repository.Dto;
using NepFit.Repository.Entity;
using NepFit.Repository.Repository.Interface;

namespace NepFit.BL
{
    public class NutritionService : INutritionService
    {
        private readonly INutritionRepository _nutritionRepository;
        private readonly IMapper _mapper;
        public NutritionService(INutritionRepository nutritionRepository, IMapper mapper)
        {
            _nutritionRepository = nutritionRepository;
            _mapper = mapper;
        }

        public int AddNutrition(NutritionCreateDto inputDto)
        { 
            return _nutritionRepository.Add(_mapper.Map<Nutrition>(inputDto));
        }
    }
}