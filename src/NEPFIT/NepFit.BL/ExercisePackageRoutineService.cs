using AutoMapper;
using NepFit.BL.Interface;
using NepFit.Repository.Dto;
using NepFit.Repository.Entity;
using NepFit.Repository.Repository.Interface;
using System;
using System.Collections.Generic;

namespace NepFit.BL
{
    public class ExercisePackageRoutineService : IExercisePackageRoutineService
    {
        private readonly IExercisePackageRoutineRepository _ExercisePackageRoutineRepository;
        private readonly IMapper _mapper;

        public ExercisePackageRoutineService(IExercisePackageRoutineRepository ExercisePackageRoutineRepository, IMapper mapper)
        {
            _ExercisePackageRoutineRepository = ExercisePackageRoutineRepository;
            _mapper = mapper;
        }

        public int Add(ExercisePackageRoutineCreateDto inputDto)
        {
            inputDto.DateCreated = DateTime.Now;
            inputDto.DateUpdated = DateTime.Now;
            inputDto.UpdatedBy = inputDto.CreatedBy;
            inputDto.Active = true;
            return _ExercisePackageRoutineRepository.Add(_mapper.Map<ExercisePackageRoutine>(inputDto));
        }

        public bool Update(ExercisePackageRoutineUpdateDto input)
        {
            var original = _ExercisePackageRoutineRepository.GetById(input.ExercisePackageRoutineId);
            original.DateUpdated = DateTime.Now;
            _mapper.Map(input, original);
            _ExercisePackageRoutineRepository.Update(original);
            return true;
        }

        public IEnumerable<ExercisePackageRoutineResultDto> GetAll()
        {
            return
               
                _ExercisePackageRoutineRepository.GetAll();
        }

        public bool Delete(ExercisePackageRoutineUpdateDto input)
        {
            var deleteObj = _mapper.Map<ExercisePackageRoutine>(input);
            deleteObj.DateUpdated = DateTime.Now;
            return _ExercisePackageRoutineRepository.Delete(deleteObj);
        }
    }
}
