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
    public class NutritionTypeService : INutritionTypeService
    {
        private readonly INutritionTypeRepository _NutritionTypeRepository;
        private readonly IMapper _mapper;

        public NutritionTypeService(INutritionTypeRepository NutritionTypeRepository, IMapper mapper)
        {
            _NutritionTypeRepository = NutritionTypeRepository;
            _mapper = mapper;
        }

        public int Add(NutritionTypeCreateDto inputDto)
        {
            inputDto.DateCreated = DateTime.Now;
            inputDto.DateUpdated = DateTime.Now;
            inputDto.UpdatedBy = inputDto.CreatedBy;
            inputDto.Active = true;
            return _NutritionTypeRepository.Add(_mapper.Map<NutritionType>(inputDto));
        }

        public bool Update(NutritionTypeUpdateDto input)
        {
            var original = _NutritionTypeRepository.GetById(input.NutritionTypeId);
            original.DateUpdated = DateTime.Now;
            _mapper.Map(input, original);
            _NutritionTypeRepository.Update(original);
            return true;
        }

        public IEnumerable<NutritionTypeResultDto> GetAll()
        {
            return
                _mapper.Map<IEnumerable<NutritionTypeResultDto>>(
                _NutritionTypeRepository.GetAll());
        }

        public bool Delete(NutritionTypeUpdateDto input)
        {
            var deleteObj = _mapper.Map<NutritionType>(input);
            deleteObj.DateUpdated = DateTime.Now;
            return _NutritionTypeRepository.Delete(deleteObj);
        }
    }
}
