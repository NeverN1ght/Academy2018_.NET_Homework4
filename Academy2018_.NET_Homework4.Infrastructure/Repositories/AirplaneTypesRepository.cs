using System.Collections.Generic;
using System.Linq;
using Academy2018_.NET_Homework4.Infrastructure.Abstractions;
using Academy2018_.NET_Homework4.Infrastructure.Data;
using Academy2018_.NET_Homework4.Infrastructure.Models;

namespace Academy2018_.NET_Homework4.Infrastructure.Repositories
{
    public class AirplaneTypesRepository: IRepository<AirplaneType>
    {
        private readonly DataSource _dataSource;

        public AirplaneTypesRepository(DataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public IEnumerable<AirplaneType> Get()
        {
            return _dataSource.AirplaneTypes;
        }

        public object Create(AirplaneType entity)
        {
            entity.Id = _dataSource.AirplaneTypes.Max(a => a.Id) + 1;
            _dataSource.AirplaneTypes.Add(entity);

            return entity.Id;
        }

        public void Update(object id, AirplaneType entity)
        {
            Delete(id);
            entity.Id = (int)id;
            _dataSource.AirplaneTypes.Add(entity);
        }

        public void Delete(object id)
        {
            var entity = _dataSource.AirplaneTypes.Find(a => a.Id == (int)id);
            Delete(entity);
        }

        public void Delete(AirplaneType entity)
        {
            _dataSource.AirplaneTypes.Remove(entity);
        }

        public bool IsExist(object id)
        {
            return _dataSource.AirplaneTypes.FirstOrDefault(a => a.Id == (int) id) != null;
        }
    }
}
