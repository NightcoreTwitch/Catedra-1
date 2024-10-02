using Catedra1_Gabriel_Cruz.src.DTOs;
namespace Catedra1_Gabriel_Cruz.src.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDTO>> GetUsers();
        Task CreateUser(UserDTO user);
        Task UpdateUser(UserDTO user);
        Task DeleteUser(UserDTO user);
        Task<bool> ExistUser(string rut);
    }
}