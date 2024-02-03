using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary1.Entities;

[Index(nameof(KennelName), IsUnique = true)]

public class KennelEntity
{
    [Key]
    public int KennelId { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string KennelName { get; set; } = null!;
}
