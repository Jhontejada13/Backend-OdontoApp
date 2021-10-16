using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendOdontoApp.API.Data.Entities
{
    public class Appointment
    {
        public int Id { get; set; }

        [Display(Name = "Fecha")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateTime Date { get; set; }

        [Display(Name = "¿Canelada?")]
        public bool IsCancelated { get; set; }
    }
}
