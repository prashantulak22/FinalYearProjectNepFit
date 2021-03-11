using System;
using System.Collections.Generic;
using AutoMapper;
using NepFit.BL.Interface;
using NepFit.Repository.Dto;
using NepFit.Repository.Entity;
using NepFit.Repository.Repository;
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

        public int Add(NutritionPackageCreateDto inputDto)
        {
            inputDto.DateCreated = DateTime.Now;
            inputDto.DateUpdated = DateTime.Now;
            inputDto.UpdatedBy = inputDto.CreatedBy;
            inputDto.Active = true;
            return _nutritionPackageRepository.Add(_mapper.Map<NutritionPackage>(inputDto));
        }

        public bool Update(NutritionPackageUpdateDto input)
        {
            var original = _nutritionPackageRepository.GetById(input.NutritionPackageId);
            original.DateUpdated = DateTime.Now;
            _mapper.Map(input, original);
            _nutritionPackageRepository.Update(original);
            return true;
        }

        public IEnumerable<NutritionPackageResultDto> GetAll()
        {
            return
                _mapper.Map<IEnumerable<NutritionPackageResultDto>>(
                _nutritionPackageRepository.GetAll());
        }

        public bool Delete(NutritionPackageUpdateDto input)
        {
            var deleteObj = _mapper.Map<NutritionPackage>(input);
            deleteObj.DateUpdated = DateTime.Now;
            return _nutritionPackageRepository.Delete(deleteObj);
        }
    }
}
