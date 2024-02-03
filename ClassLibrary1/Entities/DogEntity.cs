using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary1.Entities;

public class DogEntity
{
    [Key]
    public int DogId { get; set; }

    [Required]
    public DateTime BirthDate { get; set; }

    [Required]
    public string BirthName { get; set; } = null!;

    public string? NickName { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(10)")]
    public string Sex { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(ColorEntity))]
    public int ColorId { get; set; }

    [Required]
    [ForeignKey(nameof(BreedEntity))]
    public int BreedId { get; set; }

    [Required]
    [ForeignKey(nameof(OwnerEntity))]
    public int OwnerId { get; set; }

    [Required]
    [ForeignKey(nameof(KennelEntity))]
    public int KennelId { get; set; }

    public virtual ColorEntity Color { get; set; } = null!;

    public virtual BreedEntity Breed { get; set; } = null!;

    public virtual OwnerEntity Owner { get; set; } = null!;

    public virtual KennelEntity Kennel { get; set; } = null!;
}
