using AutoMapper;
using NepFit.BL.Interface;
using NepFit.Repository.Dto;
using NepFit.Repository.Entity;
using NepFit.Repository.Repository.Interface;
using System;
using System.Collections.Generic;


namespace NepFit.BL
{
    public class NepFitUserService : INepFitUserService
    {
        private readonly INepFitUserRepository _nepFitUserRepository;
        private readonly IMapper _mapper;

        public NepFitUserService(INepFitUserRepository nepFitUserRepository, IMapper mapper)
        {
            _nepFitUserRepository = nepFitUserRepository;
            _mapper = mapper;
        }

        public int Add(NepFitUserCreateDto inputDto)
        {
            inputDto.DateCreated = DateTime.Now;
            inputDto.DateUpdated = DateTime.Now;
            inputDto.UpdatedBy = inputDto.CreatedBy;
            inputDto.Active = true;
            return _nepFitUserRepository.Add(_mapper.Map<NepFitUser>(inputDto));
        }

        public bool Update(NepFitUserUpdateDto input)
        {
            var original = _nepFitUserRepository.GetById(input.UserId);
            original.DateUpdated = DateTime.Now;
            _mapper.Map(input, original);
            _nepFitUserRepository.Update(original);
            return true;
        }

        public IEnumerable<NepFitUserResultDto> GetAll()
        {
            return
                _mapper.Map<IEnumerable<NepFitUserResultDto>>(
                _nepFitUserRepository.GetAll());
        }

        public bool Delete(NepFitUserUpdateDto input)
        {
            var deleteObj = _mapper.Map<NepFitUser>(input);
            deleteObj.DateUpdated = DateTime.Now;
            return _nepFitUserRepository.Delete(deleteObj);
        }
    }
}
