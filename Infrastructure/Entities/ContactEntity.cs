using Infrastructure.Dtos;

namespace Infrastructure.Entities;

public class ContactEntity
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Service { get; set; }
    public string Message { get; set; } = null!;
    public DateTime? Created { get; set;}
    public DateTime? LastUpdated { get; set;}

    public static implicit operator ContactEntity(ContactDto dto)
    {
        return new ContactEntity
        {
            FullName = dto.FullName,
            Email = dto.Email,
            Service = dto.Service,
            Message = dto.Message,
            Created = dto.Created,
            LastUpdated = dto.LastUpdated,
        };
    }
}
