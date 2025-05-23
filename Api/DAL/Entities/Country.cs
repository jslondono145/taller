using System.ComponentModel.DataAnnotations;

namespace Api.DAL.Entities
{
    public class Country : AuditBase
    {
        [Display(Name = "Pa�s")] 
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener m�ximo {1} caracteres.")] 
        [Required(ErrorMessage = "El campo {0} es obligatorio.")] 
        public string Name { get; set; }

    }
}
