using Microsoft.AspNetCore.Mvc;
using Catedra1_Gabriel_Cruz.src.Interfaces;
using Catedra1_Gabriel_Cruz.src.DTOs;
namespace Catedra1_Gabriel_Cruz.src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserDTO userDTO)
        {
            if(!ModelState.IsValid) return BadRequest();
            if(await _userRepository.ExistUser(userDTO.Rut)) return Conflict();
            if(userDTO.FechaNacimiento >= DateOnly.FromDateTime(DateTime.Now)) return BadRequest();
            var newUser = await _userRepository.CreateUser(userDTO);
            return Created();
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery] string? genero = null, [FromQuery] string? orden = null)
        {
            var users = await _userRepository.GetUsers();
            if(!string.IsNullOrEmpty(genero))
            {
                var generos = new []{ "masculino", "femenino", "otro", "prefiero no decirlo"};
                if(!generos.Any(x => x.Equals(genero)))
                    return BadRequest();
                users = users.Where(x => x.Genero == genero).ToList();
            }
            if(!string.IsNullOrEmpty(orden))
            {
                if(orden == "asc")
                    users = users.OrderBy(u => u.Nombre).ToList();
                else if(orden == "desc")
                    users = users.OrderByDescending(u => u.Nombre).ToList();
                else
                    return BadRequest();
            }
            return Ok(users);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int ID, UserDTO userDTO)
        {
            if(!await _userRepository.ExistUserId(ID))
                return NotFound();
            if(!ModelState.IsValid)
                return BadRequest();
            if(userDTO.FechaNacimiento >= DateOnly.FromDateTime(DateTime.Now))
                return BadRequest();
            if(!_userRepository.GetUserDTO(userDTO.Rut).Equals(_userRepository.GetUserDTOId(ID)))
                return BadRequest();
            await _userRepository.UpdateUser(ID, userDTO);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int ID)
        {
            if(!await _userRepository.ExistUserId(ID))
                return NotFound();
            await _userRepository.DeleteUser(ID);
            return Ok();
        }
    }
}