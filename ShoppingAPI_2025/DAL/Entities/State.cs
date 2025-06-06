using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ShoppingAPI_2025.DAL.Entities
{
    public class State: AuditBase
    {
        [Display(Name = "State/Department")]
        [MaxLength(50, ErrorMessage = "The {0} field must have a maximum of {1} characters.")]
        [Required(ErrorMessage = "The {0} field is required")]
        public string StateName { get; set; } = string.Empty;

        [Display(Name = "Country")]
        [JsonIgnore]
        public Country? AssociatedCountry { get; set; }

        [Display(Name = "Country Id")]
        public Guid AssociatedCountryId { get; set; }
    }
}
