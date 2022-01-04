using Common;
using EFCore.Mysql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bol.Repositorys.Interface
{
    public interface IUserRepository<TEntity> : IMysqlRepository<TEntity>, IBolDependency
    {
    }
}
