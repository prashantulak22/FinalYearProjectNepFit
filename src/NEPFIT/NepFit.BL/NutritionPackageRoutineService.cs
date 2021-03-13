using AutoMapper;
using NepFit.BL.Interface;
using NepFit.Repository.Dto;
using NepFit.Repository.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace NepFit.BL
{
    public class NutritionPackageRoutineService : INutritionPackageRoutineService
    {
        private readonly INutritionPackageRoutineRepository _NutritionPackageRoutineRepository;
        private readonly IMapper _mapper;

        public NutritionPackageRoutineService(INutritionPackageRoutineRepository NutritionPackageRoutineRepository, IMapper mapper)
        {
            _NutritionPackageRoutineRepository = NutritionPackageRoutineRepository;
            _mapper = mapper;
        }

        public int Add(NutritionPackageRoutineCreateDto inputDto)
        {
            inputDto.DateCreated = DateTime.Now;
            inputDto.DateUpdated = DateTime.Now;
            inputDto.UpdatedBy = inputDto.CreatedBy;
            inputDto.Active = true;
            return _NutritionPackageRoutineRepository.Add(_mapper.Map<NutritionPackageRoutine>(inputDto));
        }

        public bool Update(NutritionPackageRoutineUpdateDto input)
        {
            var original = _NutritionPackageRoutineRepository.GetById(input.NutritionPackageRoutineId);
            original.DateUpdated = DateTime.Now;
            _mapper.Map(input, original);
            _NutritionPackageRoutineRepository.Update(original);
            return true;
        }

        public IEnumerable<NutritionPackageRoutineResultDto> GetAll()
        {
            return
                _mapper.Map<IEnumerable<NutritionPackageRoutineResultDto>>(
                _NutritionPackageRoutineRepository.GetAll());
        }

        public bool Delete(NutritionPackageRoutineUpdateDto input)
        {
            var deleteObj = _mapper.Map<NutritionPackageRoutine>(input);
            deleteObj.DateUpdated = DateTime.Now;
            return _NutritionPackageRoutineRepository.Delete(deleteObj);
        }
    }
}
