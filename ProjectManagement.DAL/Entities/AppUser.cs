using Microsoft.AspNetCore.Identity;

namespace ProjectManagement.DAL.Entities;

public sealed class AppUser : IdentityUser
{
    public string FullName { get; set; } = string.Empty;
    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
}
