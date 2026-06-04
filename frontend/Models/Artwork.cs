namespace frontend.Models;

using System.ComponentModel.DataAnnotations;

public class Artwork
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    [StringLength(255, MinimumLength = 1)]
    public string Title { get; set; } = default!;
    [Required]
    [StringLength(255, MinimumLength = 1)]
    public string Author { get; set; } = default!;
    [Required]
    public short? Year { get; set; }
    [Required]
    [StringLength(65535, MinimumLength = 1)]
    public string Description { get; set; } = default!;
    [Required]
    [StringLength(255, MinimumLength = 1)]
    public string Technique { get; set; } = default!;
    [Required]
    [StringLength(4096, MinimumLength = 1)]
    public string ImageUrl { get; set; } = default!;
    public Guid? ExhibitionId { get; set; } = null;
}
