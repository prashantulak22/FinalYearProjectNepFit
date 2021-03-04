using AutoMapper;
using NepFit.BL.Interface;
using NepFit.Repository.Dto;
using NepFit.Repository.Entity;
using NepFit.Repository.Repository.Interface;

namespace NepFit.BL
{
    public class NutritionPackageService : INutritionPackageService
    {
        private readonly INutritionPackageRepository _nutritionPackageRepository;
        private readonly IMapper _mapper;

        public NutritionPackageService(INutritionPackageRepository nutritionPackageRepository, IMapper mapper)
        {
            _nutritionPackageRepository = nutritionPackageRepository;
            _mapper = mapper;
        }

        public int AddNutritionPackage(NutritionPackageCreateDto inputDto)
        {
            return _nutritionPackageRepository.Add(_mapper.Map<NutritionPackage>(inputDto));
        }
    }
}
