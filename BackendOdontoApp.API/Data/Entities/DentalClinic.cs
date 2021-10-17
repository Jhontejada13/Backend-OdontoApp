using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackendOdontoApp.API.Data.Entities
{
    public class DentalClinic
    {
        public int Id { get; set; }

        [Display(Name = "Nombre de la clínica")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }

        public ICollection<Appointment> Appointments { get; set; }

    }
}
