using System.Collections.Generic;
using System.Linq;
using Academy2018_.NET_Homework4.Infrastructure.Abstractions;
using Academy2018_.NET_Homework4.Infrastructure.Data;
using Academy2018_.NET_Homework4.Infrastructure.Models;

namespace Academy2018_.NET_Homework4.Infrastructure.Repositories
{
    public class CrewsRepository: IRepository<Crew>
    {
        private readonly DataSource _dataSource;

        public CrewsRepository(DataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public IEnumerable<Crew> Get()
        {
            return _dataSource.Crews;
        }

        public object Create(Crew entity)
        {
            entity.Id = _dataSource.Crews.Max(c => c.Id) + 1;
            _dataSource.Crews.Add(entity);

            return entity.Id;
        }

        public void Update(object id, Crew entity)
        {
            Delete(id);
            entity.Id = (int)id;
            _dataSource.Crews.Add(entity);
        }

        public void Delete(object id)
        {
            var entity = _dataSource.Crews.Find(c => c.Id == (int) id);
            Delete(entity);
        }

        public void Delete(Crew entity)
        {
            _dataSource.Crews.Remove(entity);
        }

        public bool IsExist(object id)
        {
            return _dataSource.Crews.FirstOrDefault(c => c.Id == (int) id) != null;
        }
    }
}
