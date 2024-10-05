using Catedra1_Gabriel_Cruz.src.DTOs;
using Catedra1_Gabriel_Cruz.src.Models;
namespace Catedra1_Gabriel_Cruz.src.Interfaces
{
    public interface IUserRepository
    {
        Task <IEnumerable<UserDTO>> GetUsers();
        Task <User> CreateUser(UserDTO user);
        Task UpdateUser(int ID, UserDTO userDTO);
        Task DeleteUser(int ID);
        Task <bool> ExistUser(string rut);
        Task <bool> ExistUserId(int Id);
        Task <UserDTO> GetUserDTO (string rut);
    }
}