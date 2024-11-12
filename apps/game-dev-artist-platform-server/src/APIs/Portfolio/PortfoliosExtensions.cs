using GameDevArtistPlatform.APIs.Dtos;
using GameDevArtistPlatform.Infrastructure.Models;

namespace GameDevArtistPlatform.APIs.Extensions;

public static class PortfoliosExtensions
{
    public static Portfolio ToDto(this PortfolioDbModel model)
    {
        return new Portfolio
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static PortfolioDbModel ToModel(
        this PortfolioUpdateInput updateDto,
        PortfolioWhereUniqueInput uniqueId
    )
    {
        var portfolio = new PortfolioDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            portfolio.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            portfolio.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return portfolio;
    }
}
