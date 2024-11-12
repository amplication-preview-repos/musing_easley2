using GameDevArtistPlatform.APIs.Dtos;
using GameDevArtistPlatform.Infrastructure.Models;

namespace GameDevArtistPlatform.APIs.Extensions;

public static class MentorProfilesExtensions
{
    public static MentorProfile ToDto(this MentorProfileDbModel model)
    {
        return new MentorProfile
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static MentorProfileDbModel ToModel(
        this MentorProfileUpdateInput updateDto,
        MentorProfileWhereUniqueInput uniqueId
    )
    {
        var mentorProfile = new MentorProfileDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            mentorProfile.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            mentorProfile.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return mentorProfile;
    }
}
