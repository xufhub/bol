using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Mysql
{
    public class MysqlRepository<TEntity> : AppDBContext, IMysqlRepository<TEntity> where TEntity : BaseEntity
    {
        public MysqlRepository(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        protected DbSet<TEntity> Db { get; set; }

        public TEntity GetEntityById(int id)
        {
            return Db.Where(d => d.Id == id).FirstOrDefault(); 
        }

        public List<TEntity> GetEntitiesByIds(List<int> ids)
        {
            return Db.Where(d => ids.Contains(d.Id)).ToList();
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            await Db.AddAsync(entity);
            await SaveChangesAsync();
            return entity;
        }

        public async Task<long> BatchInsertAsync(List<TEntity> entity)
        {
            await Db.AddRangeAsync(entity);
            return await SaveChangesAsync();
        }

        public async Task<long> DeleteByIdAsync(int id)
        {
            var model = GetEntityById(id);
            if (model == null)
                return 0;
            Db.Remove(model);
            return await SaveChangesAsync();
        }

        public async Task<long> DeleteByIdsAsync(List<int> ids)
        {
            var models = GetEntitiesByIds(ids);
            if (models == null || models.Count < 1)
                return 0;
            Db.RemoveRange(models);
            return await SaveChangesAsync();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var model = Db.Update(entity).Entity;
            await SaveChangesAsync();
            return model;
        }
    }
}
