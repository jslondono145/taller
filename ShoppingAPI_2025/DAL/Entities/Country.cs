using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ShoppingAPI_2025.DAL.Entities
{
    public class Country: AuditBase
    {
        [Display(Name="Country")]
        [MaxLength(50, ErrorMessage = "The {0} field must have a maximum of {1} characters.")]
        [Required(ErrorMessage = "The {0} field is required")]
        public string CountryName { get; set; } = string.Empty;

        [Display(Name = "States/Departments")]
        [JsonIgnore]
        public ICollection<State>? StatesList { get; set; }
    }
}
