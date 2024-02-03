using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary1.Entities;

[Index(nameof(BreedName), IsUnique = true)]

public class BreedEntity
{
    [Key]
    public int BreedId { get; set; }


    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string BreedName { get; set; } = null!;


    [Column(TypeName = "nvarchar(20)")]
    public string? SizeClass { get; set; }
}
