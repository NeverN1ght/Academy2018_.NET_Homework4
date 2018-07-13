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
    public class DeparturesService: IService<DepartureDto>
    {
        private readonly IRepository<Departure> _repository;
        private readonly IMapper _mapper;
        private readonly AbstractValidator<DepartureDto> _validator;

        public DeparturesService(
            IRepository<Departure> repository, 
            IMapper mapper,
            AbstractValidator<DepartureDto> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }

        public IEnumerable<DepartureDto> GetAll()
        {
            return _mapper.Map<IEnumerable<Departure>, IEnumerable<DepartureDto>>(
                _repository.Get());
        }

        public DepartureDto GetById(object id)
        {
            var response = _mapper.Map<Departure, DepartureDto>(
                _repository.Get().FirstOrDefault(d => d.Id == (int)id));

            if (response == null)
            {
                throw new NotExistException();
            }

            return response;
        }

        public object Add(DepartureDto dto)
        {
            if (dto == null)
            {
                throw new NullBodyException();
            }

            var validationResult = _validator.Validate(dto);

            if (validationResult.IsValid)
            {
                return _repository.Create(
                    _mapper.Map<DepartureDto, Departure>(dto));
            }

            throw new ValidationException(validationResult.Errors);
        }

        public void Update(object id, DepartureDto dto)
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
                        _mapper.Map<DepartureDto, Departure>(dto));
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
