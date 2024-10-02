using System.ComponentModel.DataAnnotations;
namespace Catedra1_Gabriel_Cruz.src.DTOs
{
    public class UserDTO
    {
        public string Rut { get; set; } = string.Empty;
        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres.")]
        public string Nombre { get; set; } = string.Empty;
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Correo { get; set; } = string.Empty;
        [Required]
        [RegularExpression("^(masculino|femenino|otro|prefiero no decirlo)$", ErrorMessage = "Las categorías permitidas son: 'masculino', 'femenino', 'otro' o 'prefiero no decirlo'.")]
        public string Genero { get; set; } = string.Empty;
        [Required(ErrorMessage = "Este campo es requerido")]
        public DateTime FechaNacimiento { get; set; }
    }
}