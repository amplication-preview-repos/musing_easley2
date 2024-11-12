using GameDevArtistPlatform.Core.Enums;

namespace GameDevArtistPlatform.APIs.Dtos;

public class User
{
    public string? CareerGoals { get; set; }

    public CareerPathEnum? CareerPath { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Email { get; set; }

    public string? Experience { get; set; }

    public string? FirstName { get; set; }

    public string Id { get; set; }

    public string? LastName { get; set; }

    public string Password { get; set; }

    public RoleEnum? Role { get; set; }

    public string Roles { get; set; }

    public string? SkillLevel { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string Username { get; set; }
}
