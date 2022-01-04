using bolApi.Intserface;
using Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bolApi.Controllers
{
    [Route("api/[Controller]/[Action]")]
    public class UserController : ApiBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [ActionName("get")]
        public ApiReturn Get(int id)
        {
            var user = _userService.GetUsers(id);
            Hashtable ht = new Hashtable();
            return ApiReturn.Succeed.SetDatas("user", user, "id", user.Id);
        }
    }
}
