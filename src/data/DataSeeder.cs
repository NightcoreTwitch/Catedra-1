using Catedra1_Gabriel_Cruz.src.data;
using Catedra1_Gabriel_Cruz.src.Models;
namespace Catedra1_Gabriel_Cruz.src.Models
{
    public class DataSeeder()
    {
        public static void Initializable(AppDbContext context)
        {
            if(!context.Users.Any())
            {
                context.Users.AddRange(
                new User
                {
                    Rut = "211805307",
                    Nombre = "Fernando",
                    Correo = "fernando.lindo@gmail.com",
                    Genero = "masculino",
                    FechaNacimiento = new DateOnly(1990, 5, 15)
                },
                new User
                {
                    Rut = "123456789",
                    Nombre = "Andrea",
                    Correo = "andrea.lopez@gmail.com",
                    Genero = "femenino",
                    FechaNacimiento = new DateOnly(1992, 3, 22)
                },
                new User
                {
                    Rut = "987654321",
                    Nombre = "Carlos",
                    Correo = "carlos.martinez@gmail.com",
                    Genero = "masculino",
                    FechaNacimiento = new DateOnly(1985, 8, 10)
                },
                new User
                {
                    Rut = "192837465",
                    Nombre = "Sofia",
                    Correo = "sofia.garcia@gmail.com",
                    Genero = "femenino",
                    FechaNacimiento = new DateOnly(1995, 12, 5)
                },
                new User
                {
                    Rut = "223344556",
                    Nombre = "Javier",
                    Correo = "javier.sanchez@gmail.com",
                    Genero = "masculino",
                    FechaNacimiento = new DateOnly(1993, 7, 18)
                },
                new User
                {
                    Rut = "334455667",
                    Nombre = "Lucia",
                    Correo = "lucia.fernandez@gmail.com",
                    Genero = "femenino",
                    FechaNacimiento = new DateOnly(1988, 2, 14)
                },
                new User
                {
                    Rut = "445566778",
                    Nombre = "Miguel",
                    Correo = "miguel.diaz@gmail.com",
                    Genero = "masculino",
                    FechaNacimiento = new DateOnly(1991, 11, 28)
                },
                new User
                {
                    Rut = "556677889",
                    Nombre = "Paula",
                    Correo = "paula.morales@gmail.com",
                    Genero = "femenino",
                    FechaNacimiento = new DateOnly(1996, 9, 10)
                },
                new User
                {
                    Rut = "667788990",
                    Nombre = "Francisco",
                    Correo = "francisco.ruiz@gmail.com",
                    Genero = "otro",
                    FechaNacimiento = new DateOnly(1987, 6, 7)
                },
                new User
                {
                    Rut = "778899001",
                    Nombre = "Camila",
                    Correo = "camila.torres@gmail.com",
                    Genero = "prefiero no decirlo",
                    FechaNacimiento = new DateOnly(1994, 4, 20)
                }
                );
                context.SaveChanges();
            }
        }
    }
}