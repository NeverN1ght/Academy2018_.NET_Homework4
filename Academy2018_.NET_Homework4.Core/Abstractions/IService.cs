using System.Collections.Generic;

namespace Academy2018_.NET_Homework4.Core.Abstractions
{
    public interface IService<TDto> 
        where TDto: class
    {
        IEnumerable<TDto> GetAll();

        TDto GetById(object id);

        object Add(TDto dto);

        void Update(object id, TDto dto);

        void Delete(object id);
    }
}
