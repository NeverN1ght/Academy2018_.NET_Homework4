using System.Collections.Generic;
using System.Linq;
using Academy2018_.NET_Homework4.Infrastructure.Abstractions;
using Academy2018_.NET_Homework4.Infrastructure.Data;
using Academy2018_.NET_Homework4.Infrastructure.Models;

namespace Academy2018_.NET_Homework4.Infrastructure.Repositories
{
    public class AirplanesRepository: IRepository<Airplane>
    {
        private readonly DataSource _dataSource;

        public AirplanesRepository(DataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public IEnumerable<Airplane> Get()
        {
            return _dataSource.Airplanes;
        }

        public object Create(Airplane entity)
        {
            entity.Id = _dataSource.Airplanes.Max(a => a.Id) + 1;
            _dataSource.Airplanes.Add(entity);

            return entity.Id;
        }

        public void Update(object id, Airplane entity)
        {
            Delete(id);
            entity.Id = (int)id;
            _dataSource.Airplanes.Add(entity);
        }

        public void Delete(object id)
        {
            var entity = _dataSource.Airplanes.Find(a => a.Id == (int) id);
            Delete(entity);
        }

        public void Delete(Airplane entity)
        {
            _dataSource.Airplanes.Remove(entity);
        }

        public bool IsExist(object id)
        {
            return _dataSource.Airplanes.FirstOrDefault(a => a.Id == (int) id) != null;
        }
    }
}
