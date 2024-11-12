using GameDevArtistPlatform.APIs.Dtos;
using GameDevArtistPlatform.Infrastructure.Models;

namespace GameDevArtistPlatform.APIs.Extensions;

public static class AnalyticsItemsExtensions
{
    public static Analytics ToDto(this AnalyticsDbModel model)
    {
        return new Analytics
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static AnalyticsDbModel ToModel(
        this AnalyticsUpdateInput updateDto,
        AnalyticsWhereUniqueInput uniqueId
    )
    {
        var analytics = new AnalyticsDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            analytics.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            analytics.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return analytics;
    }
}
