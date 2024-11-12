using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GameDevArtistPlatform.Core.Enums;

namespace GameDevArtistPlatform.Infrastructure.Models;

[Table("Users")]
public class UserDbModel
{
    [StringLength(1000)]
    public string? CareerGoals { get; set; }

    public CareerPathEnum? CareerPath { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    public string? Email { get; set; }

    [StringLength(1000)]
    public string? Experience { get; set; }

    [StringLength(256)]
    public string? FirstName { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(256)]
    public string? LastName { get; set; }

    [Required()]
    public string Password { get; set; }

    public RoleEnum? Role { get; set; }

    [Required()]
    public string Roles { get; set; }

    [StringLength(1000)]
    public string? SkillLevel { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }

    [Required()]
    public string Username { get; set; }
}
