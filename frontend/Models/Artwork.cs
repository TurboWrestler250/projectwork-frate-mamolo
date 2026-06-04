namespace frontend.Models;

using System.ComponentModel.DataAnnotations;

public class Artwork
{
    public int Id { get; set; }
    [Required]
    [StringLength(255, MinimumLength = 1)]
    public string Title { get; set; } = default!;
    [Required]
    [StringLength(255, MinimumLength = 1)]
    public string Author { get; set; } = default!;
    public short Year { get; set; }
    [Required]
    [StringLength(10000, MinimumLength = 1)]
    public string Description { get; set; } = default!;
    [Required]
    [StringLength(100, MinimumLength = 1)]
    public string Technique { get; set; } = default!;
    [Required]
    [StringLength(1000, MinimumLength = 1)]
    public string ImageUrl { get; set; } = default!;
    public int? ExhibitionId { get; set; } = null;
}
