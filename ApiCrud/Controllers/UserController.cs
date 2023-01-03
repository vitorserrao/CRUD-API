using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiCrud.Models;
using ApiCrud.Repository.Interface;

namespace ApiCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase

    {
        private readonly IUser _repositoryUser;
        public UserController(IUser repositoryUser)
        {
            _repositoryUser = repositoryUser;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> SearchUserFull()
        {
            List<UserModel> users =  await _repositoryUser.SearchUserFull();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> SearchUserId(int id)
        {   
            UserModel users = await _repositoryUser.SearchUsersId(id);
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> RegisterUser([FromBody] UserModel user)
        {
            UserModel userRegister = await _repositoryUser.AddUser(user);
            return Ok(userRegister);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> UpdateUser([FromBody] UserModel user, int id)
        {
            user.Id = id;
            UserModel userRegister = await _repositoryUser.UpdateUser(user, id);
            return Ok(userRegister);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModel>> RemoveUser(int id)
        {
            Boolean userRemove = await _repositoryUser.DeteteUser(id);
            return Ok(userRemove);
        }

     
    }


}