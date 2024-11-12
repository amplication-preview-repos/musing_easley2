using GameDevArtistPlatform.APIs.Common;
using GameDevArtistPlatform.APIs.Dtos;

namespace GameDevArtistPlatform.APIs;

public interface IRewardsService
{
    /// <summary>
    /// Create one Reward
    /// </summary>
    public Task<Reward> CreateReward(RewardCreateInput reward);

    /// <summary>
    /// Delete one Reward
    /// </summary>
    public Task DeleteReward(RewardWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Rewards
    /// </summary>
    public Task<List<Reward>> Rewards(RewardFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Reward records
    /// </summary>
    public Task<MetadataDto> RewardsMeta(RewardFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Reward
    /// </summary>
    public Task<Reward> Reward(RewardWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Reward
    /// </summary>
    public Task UpdateReward(RewardWhereUniqueInput uniqueId, RewardUpdateInput updateDto);
}
