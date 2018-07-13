using System.Collections.Generic;
using System.Linq;
using Academy2018_.NET_Homework4.Core.Abstractions;
using Academy2018_.NET_Homework4.Infrastructure.Abstractions;
using Academy2018_.NET_Homework4.Infrastructure.Models;
using Academy2018_.NET_Homework4.Shared.DTOs;
using Academy2018_.NET_Homework4.Shared.Exceptions;
using AutoMapper;
using FluentValidation;

namespace Academy2018_.NET_Homework4.Core.Services
{
    public class AirplaneTypesService: IService<AirplaneTypeDto>
    {
        private readonly IRepository<AirplaneType> _repository;
        private readonly IMapper _mapper;
        private readonly AbstractValidator<AirplaneTypeDto> _validator;

        public AirplaneTypesService(
            IRepository<AirplaneType> repository,
            IMapper mapper,
            AbstractValidator<AirplaneTypeDto> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }

        public IEnumerable<AirplaneTypeDto> GetAll()
        {
            return _mapper.Map<IEnumerable<AirplaneType>, IEnumerable<AirplaneTypeDto>>(
                _repository.Get());
        }

        public AirplaneTypeDto GetById(object id)
        {
            var response = _mapper.Map<AirplaneType, AirplaneTypeDto>(
                _repository.Get().FirstOrDefault(a => a.Id == (int)id));

            if (response == null)
            {
                throw new NotExistException();
            }

            return response;
        }

        public object Add(AirplaneTypeDto dto)
        {
            if (dto == null)
            {
                throw new NullBodyException();
            }

            var validationResult = _validator.Validate(dto);

            if (validationResult.IsValid)
            {
                return _repository.Create(
                    _mapper.Map<AirplaneTypeDto, AirplaneType>(dto));
            }

            throw new ValidationException(validationResult.Errors);
        }

        public void Update(object id, AirplaneTypeDto dto)
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
                        _mapper.Map<AirplaneTypeDto, AirplaneType>(dto));
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
