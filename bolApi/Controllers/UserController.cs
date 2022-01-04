using bolApi.Intserface;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public ActionResult Get()
        {
            var user = _userService.GetUsers(1);
            return new JsonResult(user) { ContentType = "application/json", StatusCode = 200};
        }
    }
}
