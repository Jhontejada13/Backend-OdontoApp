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

        [Display(Name = "Procedimiento")]
        public ProcedureAppoinment ProcedureAppoinment { get; set; }

        [Display(Name = "Motivo Cancelación")]
        public CancellationReason CancellationReason { get; set; }

        [Display(Name = "Usuario")]
        public User User { get; set; }

        public DentalClinic DentalClinic { get; set; }
    }
}
