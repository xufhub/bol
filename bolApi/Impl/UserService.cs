using bolApi.Intserface;
using Common;
using Bol.Repositorys.Entity;
using Bol.Repositorys.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bolApi.Impl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository<UserEntity> _userRepository;
        public UserService(IUserRepository<UserEntity> userRepository)
        {
            _userRepository = userRepository;
        }
        public UserEntity GetUsers(int id)
        {
            return _userRepository.GetEntityById(id);
        }
    }
}
