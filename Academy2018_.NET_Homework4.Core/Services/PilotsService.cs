using System.Collections.Generic;
using System.Linq;
using System.Security;
using Academy2018_.NET_Homework4.Core.Abstractions;
using Academy2018_.NET_Homework4.Infrastructure.Abstractions;
using Academy2018_.NET_Homework4.Infrastructure.Models;
using Academy2018_.NET_Homework4.Shared.DTOs;
using Academy2018_.NET_Homework4.Shared.Exceptions;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;

namespace Academy2018_.NET_Homework4.Core.Services
{
    public class PilotsService: IService<PilotDto>
    {
        private readonly IRepository<Pilot> _repository;
        private readonly IMapper _mapper;
        private readonly AbstractValidator<PilotDto> _validator;

        public PilotsService(
            IRepository<Pilot> repository, 
            IMapper mapper, 
            AbstractValidator<PilotDto> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }

        public IEnumerable<PilotDto> GetAll()
        {
            return _mapper.Map<IEnumerable<Pilot>, IEnumerable<PilotDto>>(
                _repository.Get());
        }

        public PilotDto GetById(object id)
        {
            var response = _mapper.Map<Pilot, PilotDto>(
                _repository.Get().FirstOrDefault(p => p.Id == (int)id));

            if (response == null)
            {
                throw new NotExistException();
            }

            return response;
        }

        public object Add(PilotDto dto)
        {
            if (dto == null)
            {
                throw new NullBodyException();
            }

            var validationResult = _validator.Validate(dto);

            if (validationResult.IsValid)
            {
                return _repository.Create(
                    _mapper.Map<PilotDto, Pilot>(dto));
            }

            throw new ValidationException(validationResult.Errors);
        }

        public void Update(object id, PilotDto dto)
        {
            if (dto == null)
            {
                throw new NullBodyException();
            }

            if (_repository.IsExist(id))
            {
                var validationResult = _validator.Validate(dto);

                if (validationResult.IsValid)
                {
                    _repository.Update((int)id,
                        _mapper.Map<PilotDto, Pilot>(dto));
                }
                else
                {
                    throw new ValidationException(validationResult.Errors);
                }
            }
            else
            {
                throw new NotExistException();
            }
        }

        public void Delete(object id)
        {
            if (_repository.IsExist(id))
            {
                _repository.Delete((int)id);
            }
            else
            {
                throw new NotExistException();
            }
        }
    }
}
