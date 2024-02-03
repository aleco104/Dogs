using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary1.Entities;

[Index(nameof(ColorName), IsUnique = true)]

public class ColorEntity
{
    [Key] 
    public int ColorId { get; set; }


    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string ColorName { get; set; } = null!;
}
