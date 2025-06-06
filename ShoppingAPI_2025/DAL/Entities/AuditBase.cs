using System.ComponentModel.DataAnnotations;

namespace ShoppingAPI_2025.DAL.Entities
{
    public class AuditBase
    {
        [Key]
        [Required]
        public virtual Guid EntityId { get; set; }
        public virtual DateTime? CreationDate { get; set; }
        public virtual DateTime? LastModificationDate { get; set; }
    }
}
