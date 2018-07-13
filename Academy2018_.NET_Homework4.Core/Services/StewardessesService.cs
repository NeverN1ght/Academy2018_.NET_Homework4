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
    public class StewardessesService: IService<StewardesseDto>
    {
        private readonly IRepository<Stewardesse> _repository;
        private readonly IMapper _mapper;
        private readonly AbstractValidator<StewardesseDto> _validator;

        public StewardessesService(
            IRepository<Stewardesse> repository, 
            IMapper mapper,
            AbstractValidator<StewardesseDto> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }

        public IEnumerable<StewardesseDto> GetAll()
        {
            return _mapper.Map<IEnumerable<Stewardesse>, IEnumerable<StewardesseDto>>(
                _repository.Get());
        }

        public StewardesseDto GetById(object id)
        {
            var response = _mapper.Map<Stewardesse, StewardesseDto>(
                _repository.Get().FirstOrDefault(s => s.Id == (int)id));

            if (response == null)
            {
                throw new NotExistException();
            }

            return response;
        }

        public object Add(StewardesseDto dto)
        {
            if (dto == null)
            {
                throw new NullBodyException();
            }

            var validationResult = _validator.Validate(dto);

            if (validationResult.IsValid)
            {
                return _repository.Create(
                    _mapper.Map<StewardesseDto, Stewardesse>(dto));
            }

            throw new ValidationException(validationResult.Errors);
        }

        public void Update(object id, StewardesseDto dto)
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
                        _mapper.Map<StewardesseDto, Stewardesse>(dto));
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
