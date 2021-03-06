using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackendOdontoApp.API.Data.Entities
{
    public class Speciality
    {
        public int Id { get; set; }

        [Display(Name = "Especialidad")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Name { get; set; }

        [Display(Name = "Usuarios")]
        public ICollection<User> Users { get; set; }
    }
}
