using BaseRepository;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Mysql
{
    public interface IMysqlRepository<TEntity>: IBaseRepository<TEntity>, IBolDependency
    {
        public TEntity GetEntityById(int id);

        public List<TEntity> GetEntitiesByIds(List<int> ids);

        public Task<TEntity> InsertAsync(TEntity entity);

        public Task<long> BatchInsertAsync(List<TEntity> entity);

        public Task<long> DeleteByIdAsync(int id);
        public Task<long> DeleteByIdsAsync(List<int> ids);
        public Task<TEntity> UpdateAsync(TEntity entity);
    }
}
