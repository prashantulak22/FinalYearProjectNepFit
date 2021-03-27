using AutoMapper;
using NepFit.BL.Interface;
using NepFit.Repository.Dto;
using NepFit.Repository.Entity;
using NepFit.Repository.Repository.Interface;
using System;
using System.Collections.Generic;

namespace NepFit.BL
{
    public class UserExerciseNutritionService : IUserExerciseNutritionService
    {
        private readonly IUserExerciseNutritionRepository _userExerciseNutritionRepository;
        private readonly IMapper _mapper;

        public UserExerciseNutritionService(IUserExerciseNutritionRepository UserExerciseNutritionRepository, IMapper mapper)
        {
            _userExerciseNutritionRepository = UserExerciseNutritionRepository;
            _mapper = mapper;
        }

        public int Add(UserExerciseNutritionCreateDto inputDto)
        {
            inputDto.DateCreated = DateTime.Now;
            inputDto.DateUpdated = DateTime.Now;
            inputDto.UpdatedBy = inputDto.CreatedBy;
            inputDto.Active = true;
            return _userExerciseNutritionRepository.Add(_mapper.Map<UserExerciseNutrition>(inputDto));
        }

        public bool Update(UserExerciseNutritionUpdateDto input)
        {
            var original = _userExerciseNutritionRepository.GetById(input.UserExerciseNutritionId);
            original.DateUpdated = DateTime.Now;
            _mapper.Map(input, original);
            _userExerciseNutritionRepository.Update(original);
            return true;
        }

        public IEnumerable<UserExerciseNutritionResultDto> GetAll()
        {
            return
                 _mapper.Map<IEnumerable<UserExerciseNutritionResultDto>>(

                _userExerciseNutritionRepository.GetAll());
        }

        public bool Delete(UserExerciseNutritionUpdateDto input)
        {
            var deleteObj = _mapper.Map<UserExerciseNutrition>(input);
            deleteObj.DateUpdated = DateTime.Now;
            return _userExerciseNutritionRepository.Delete(deleteObj);
        }
    }
}
