using Microsoft.EntityFrameworkCore;
using Catedra1_Gabriel_Cruz.src.DTOs;
using Catedra1_Gabriel_Cruz.src.Interfaces;
using Catedra1_Gabriel_Cruz.src.data;
using Catedra1_Gabriel_Cruz.src.Models;
namespace Catedra1_Gabriel_Cruz.src.repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task <IEnumerable<UserDTO>> GetUsers()
        {
            var users = await _context.Users.Select(x => new UserDTO
            {
                Rut = x.Rut,
                Nombre = x.Nombre,
                Correo = x.Correo,
                Genero = x.Genero,
                FechaNacimiento = x.FechaNacimiento
            }).ToListAsync();
            return users;
        }
        public async Task <User> CreateUser(UserDTO userDTO)
        {
            var newUser = new User
            {
                Rut = userDTO.Rut,
                Nombre = userDTO.Nombre,
                Correo = userDTO.Correo,
                Genero = userDTO.Genero,
                FechaNacimiento = userDTO.FechaNacimiento
            };
            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }
        public async Task UpdateUser(int ID, UserDTO userDTO)
        {
            var user = await _context.Users.FindAsync(ID);
            user.Rut = userDTO.Rut;
            user.Nombre = userDTO.Nombre;
            user.Correo = userDTO.Correo;
            user.Genero = userDTO.Genero;
            user.FechaNacimiento = userDTO.FechaNacimiento;
            _context.Update(user);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteUser(int ID)
        {
            var user = await _context.Users.FindAsync(ID);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
        public async Task <bool> ExistUser(string rut)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Rut == rut) is not null;
        }
        public async Task <bool> ExistUserId(int Id)
        {
            return await _context.Users.FindAsync(Id) is not null;
        }
        public async Task <UserDTO> GetUserDTO (string rut)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Rut == rut);
            if (user is null)
                return null;
            else 
            {
                return new UserDTO
                {
                    Rut = user.Rut,
                    Nombre = user.Nombre,
                    Correo = user.Correo,
                    Genero = user.Genero,
                    FechaNacimiento = user.FechaNacimiento
                };
            }
        }
    }
}