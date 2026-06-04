namespace backend.ApiService.Models;

using System.ComponentModel.DataAnnotations;

public class Exhibition
{
    public int Id { get; set; }
    [Required]
    [StringLength(255, MinimumLength = 1)]
    public string Title { get; set; } = default!;
    [Required]
    [StringLength(65535, MinimumLength = 1)]
    public string Description { get; set; } = default!;
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime StartDate { get; set; }
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime EndDate { get; set; }
    [Required]
    [StringLength(4096, MinimumLength = 1)]
    public string ImageUrl { get; set; } = default!;
    [Required]
    [RegularExpression("^(Active|Upcoming|Archived)$")]
    public string Status { get; set; } = "Upcoming";
}
