using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Dtos;

public class ContactDto
{
    [Required]
    public string FullName { get; set; } = null!;

    [Required]
    public string Email { get; set; } = null!;
    public string? Service { get; set; }

    [Required]
    public string Message { get; set; } = null!;
    public DateTime? Created { get; set; }
    public DateTime? LastUpdated { get; set; }
}
