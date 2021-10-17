using System.ComponentModel.DataAnnotations;

namespace BackendOdontoApp.API.Data.Entities
{
    public class Detail
    {
        public int Id { get; set; }

        [Display(Name = "Descripción")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Description { get; set; }

        [Display(Name = "Precio")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public decimal LaborPrice { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Procedimiento")]
        public Procedure Procedure { get; set; }

        [Display(Name = "Comentarios")]
        [DataType(DataType.MultilineText)]
        [MaxLength(300, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        public string Remarks { get; set; }
    }
}
