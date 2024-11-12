using GameDevArtistPlatform.APIs;
using GameDevArtistPlatform.APIs.Common;
using GameDevArtistPlatform.APIs.Dtos;
using GameDevArtistPlatform.APIs.Errors;
using GameDevArtistPlatform.APIs.Extensions;
using GameDevArtistPlatform.Infrastructure;
using GameDevArtistPlatform.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace GameDevArtistPlatform.APIs;

public abstract class RewardsServiceBase : IRewardsService
{
    protected readonly GameDevArtistPlatformDbContext _context;

    public RewardsServiceBase(GameDevArtistPlatformDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Reward
    /// </summary>
    public async Task<Reward> CreateReward(RewardCreateInput createDto)
    {
        var reward = new RewardDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            reward.Id = createDto.Id;
        }

        _context.Rewards.Add(reward);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<RewardDbModel>(reward.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Reward
    /// </summary>
    public async Task DeleteReward(RewardWhereUniqueInput uniqueId)
    {
        var reward = await _context.Rewards.FindAsync(uniqueId.Id);
        if (reward == null)
        {
            throw new NotFoundException();
        }

        _context.Rewards.Remove(reward);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Rewards
    /// </summary>
    public async Task<List<Reward>> Rewards(RewardFindManyArgs findManyArgs)
    {
        var rewards = await _context
            .Rewards.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return rewards.ConvertAll(reward => reward.ToDto());
    }

    /// <summary>
    /// Meta data about Reward records
    /// </summary>
    public async Task<MetadataDto> RewardsMeta(RewardFindManyArgs findManyArgs)
    {
        var count = await _context.Rewards.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Reward
    /// </summary>
    public async Task<Reward> Reward(RewardWhereUniqueInput uniqueId)
    {
        var rewards = await this.Rewards(
            new RewardFindManyArgs { Where = new RewardWhereInput { Id = uniqueId.Id } }
        );
        var reward = rewards.FirstOrDefault();
        if (reward == null)
        {
            throw new NotFoundException();
        }

        return reward;
    }

    /// <summary>
    /// Update one Reward
    /// </summary>
    public async Task UpdateReward(RewardWhereUniqueInput uniqueId, RewardUpdateInput updateDto)
    {
        var reward = updateDto.ToModel(uniqueId);

        _context.Entry(reward).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Rewards.Any(e => e.Id == reward.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
