using GameDevArtistPlatform.APIs.Dtos;
using GameDevArtistPlatform.Infrastructure.Models;

namespace GameDevArtistPlatform.APIs.Extensions;

public static class RewardsExtensions
{
    public static Reward ToDto(this RewardDbModel model)
    {
        return new Reward
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static RewardDbModel ToModel(
        this RewardUpdateInput updateDto,
        RewardWhereUniqueInput uniqueId
    )
    {
        var reward = new RewardDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            reward.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            reward.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return reward;
    }
}
