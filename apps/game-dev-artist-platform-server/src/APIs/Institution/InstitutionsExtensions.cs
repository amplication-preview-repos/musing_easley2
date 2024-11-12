using GameDevArtistPlatform.APIs.Dtos;
using GameDevArtistPlatform.Infrastructure.Models;

namespace GameDevArtistPlatform.APIs.Extensions;

public static class InstitutionsExtensions
{
    public static Institution ToDto(this InstitutionDbModel model)
    {
        return new Institution
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static InstitutionDbModel ToModel(
        this InstitutionUpdateInput updateDto,
        InstitutionWhereUniqueInput uniqueId
    )
    {
        var institution = new InstitutionDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            institution.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            institution.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return institution;
    }
}
