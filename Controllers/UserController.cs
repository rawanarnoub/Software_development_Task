using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Logging;
using WebApplication4.Models;
using WebApplication4.Services;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        public IUserService _userService { get; set; }
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("CreateUser")]
        public  IActionResult AddUser(Users  users)
        {
            try
            {
                _userService.Create(users);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.logInfo(ex.ToString());
                return BadRequest(ex.ToString());   
            }
        }
      
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                throw new NotImplementedException();
                var users = _userService.GetAll();
                return Ok(users);
            }
            catch (Exception ex)
            {
                Log.logInfo(ex.ToString());
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(id);
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Create(Users model)
        {
            _userService.Create(model);
            return Ok(new { message = "User created" });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Users model)
        {
            _userService.Update(id, model);
            return Ok(new { message = "User updated" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return Ok(new { message = "User deleted" });
        }
    }
}
