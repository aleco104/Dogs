using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary1.Entities;

public class OwnerEntity
{
    [Key]
    public int OwnerId { get; set; }


    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string OwnerName { get; set; } = null!;


    public int PhoneNumber { get; set; }


    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string Email { get; set; } = null!;


    [ForeignKey(nameof(AddressEntity))]
    public int AddressId { get; set; }


    public virtual AddressEntity Address { get; set; } = null!;
}
