namespace frontend.Models;

using System.ComponentModel.DataAnnotations;

public class GuidedTour
{
    [Required]
    public int Id { get; set; }
    [Required]
    [StringLength(100, MinimumLength = 1)]
    public string Title { get; set; } = "TITLE_DEFAULT";
    public string Description { get; set; } = "DESCRIPTION_DEFAULT";
    [Required]
    public DateTime Date { get; set; } = DateTime.Now;
    [Required]
    public TimeSpan Duration { get; set; } = TimeSpan.Zero;
    [StringLength(100, MinimumLength = 1)]
    public string GuideName { get; set; } = default!;
    [StringLength(100, MinimumLength = 1)]
    public string GuideSurname { get; set; } = default!;
    [Required]
    public int MaxParticipants { get; set; } = 1;
    public string Exhibition { get; set; } = "archived";
}
