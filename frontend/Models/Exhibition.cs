namespace frontend.Models;

using System.ComponentModel.DataAnnotations;

public class Exhibition
{
    public int Id { get; set; }
    [Required]
    [StringLength(100, MinimumLength = 1)]
    public string Title { get; set; } = default!;
    [Required]
    [StringLength(10000, MinimumLength = 1)]
    public string Description { get; set; } = default!;
    [Required]
    public DateOnly StartDate { get; set; }
    [Required]
    public DateOnly FinishDate { get; set; }
    [Required]
    [StringLength(1000, MinimumLength = 1)]
    public string ImageUrl { get; set; } = default!;
    [Required]
    [StringLength(100, MinimumLength = 1)]
    public string Status { get; set; } = default!;
}
