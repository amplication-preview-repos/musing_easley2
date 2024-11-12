using GameDevArtistPlatform.APIs.Dtos;
using GameDevArtistPlatform.Infrastructure.Models;

namespace GameDevArtistPlatform.APIs.Extensions;

public static class UsersExtensions
{
    public static User ToDto(this UserDbModel model)
    {
        return new User
        {
            CareerGoals = model.CareerGoals,
            CareerPath = model.CareerPath,
            CreatedAt = model.CreatedAt,
            Email = model.Email,
            Experience = model.Experience,
            FirstName = model.FirstName,
            Id = model.Id,
            LastName = model.LastName,
            Password = model.Password,
            Role = model.Role,
            Roles = model.Roles,
            SkillLevel = model.SkillLevel,
            UpdatedAt = model.UpdatedAt,
            Username = model.Username,
        };
    }

    public static UserDbModel ToModel(this UserUpdateInput updateDto, UserWhereUniqueInput uniqueId)
    {
        var user = new UserDbModel
        {
            Id = uniqueId.Id,
            CareerGoals = updateDto.CareerGoals,
            CareerPath = updateDto.CareerPath,
            Email = updateDto.Email,
            Experience = updateDto.Experience,
            FirstName = updateDto.FirstName,
            LastName = updateDto.LastName,
            Role = updateDto.Role,
            SkillLevel = updateDto.SkillLevel
        };

        if (updateDto.CreatedAt != null)
        {
            user.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.Password != null)
        {
            user.Password = updateDto.Password;
        }
        if (updateDto.Roles != null)
        {
            user.Roles = updateDto.Roles;
        }
        if (updateDto.UpdatedAt != null)
        {
            user.UpdatedAt = updateDto.UpdatedAt.Value;
        }
        if (updateDto.Username != null)
        {
            user.Username = updateDto.Username;
        }

        return user;
    }
}
