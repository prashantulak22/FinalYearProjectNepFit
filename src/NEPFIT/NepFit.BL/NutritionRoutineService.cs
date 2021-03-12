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
    public class NutritionRoutineService : INutritionRoutineService
    {
        private readonly INutritionRoutineRepository _NutritionRoutineRepository;
        private readonly IMapper _mapper;

        public NutritionRoutineService(INutritionRoutineRepository NutritionRoutineRepository, IMapper mapper)
        {
            _NutritionRoutineRepository = NutritionRoutineRepository;
            _mapper = mapper;
        }

        public int Add(NutritionRoutineCreateDto inputDto)
        {
            inputDto.DateCreated = DateTime.Now;
            inputDto.DateUpdated = DateTime.Now;
            inputDto.UpdatedBy = inputDto.CreatedBy;
            inputDto.Active = true;
            return _NutritionRoutineRepository.Add(_mapper.Map<NutritionRoutine>(inputDto));
        }

        public bool Update(NutritionRoutineUpdateDto input)
        {
            var original = _NutritionRoutineRepository.GetById(input.NutritionRoutineId);
            original.DateUpdated = DateTime.Now;
            _mapper.Map(input, original);
            _NutritionRoutineRepository.Update(original);
            return true;
        }

        public IEnumerable<NutritionRoutineResultDto> GetAll()
        {
            return
                _mapper.Map<IEnumerable<NutritionRoutineResultDto>>(
                _NutritionRoutineRepository.GetAll());
        }

        public bool Delete(NutritionRoutineUpdateDto input)
        {
            var deleteObj = _mapper.Map<NutritionRoutine>(input);
            deleteObj.DateUpdated = DateTime.Now;
            return _NutritionRoutineRepository.Delete(deleteObj);
        }
    }
}
