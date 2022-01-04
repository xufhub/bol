using Bol.Repositorys.Entity;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bolApi.Intserface
{
    public interface IUserService: IBolDependency
    {
        public UserEntity GetUsers(int id);
    }
}
