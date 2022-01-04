using BaseRepository;
using EFCore.Mysql;
using Microsoft.EntityFrameworkCore;
using Bol.Repositorys.Entity;
using Bol.Repositorys.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bol.Repositorys.Impl
{
    public class UserRepository<TEntity> : MysqlRepository<TEntity>, IUserRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbContextOptions<AppDBContext> _dbContext;
        public UserRepository(DbContextOptions<AppDBContext> options) : base(options)
        {
            _dbContext = options;
        }
    }
}
