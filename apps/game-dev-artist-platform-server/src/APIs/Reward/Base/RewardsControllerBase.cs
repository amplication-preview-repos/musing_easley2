using GameDevArtistPlatform.APIs;
using GameDevArtistPlatform.APIs.Common;
using GameDevArtistPlatform.APIs.Dtos;
using GameDevArtistPlatform.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace GameDevArtistPlatform.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class RewardsControllerBase : ControllerBase
{
    protected readonly IRewardsService _service;

    public RewardsControllerBase(IRewardsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Reward
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Reward>> CreateReward(RewardCreateInput input)
    {
        var reward = await _service.CreateReward(input);

        return CreatedAtAction(nameof(Reward), new { id = reward.Id }, reward);
    }

    /// <summary>
    /// Delete one Reward
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteReward([FromRoute()] RewardWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteReward(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Rewards
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Reward>>> Rewards([FromQuery()] RewardFindManyArgs filter)
    {
        return Ok(await _service.Rewards(filter));
    }

    /// <summary>
    /// Meta data about Reward records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> RewardsMeta(
        [FromQuery()] RewardFindManyArgs filter
    )
    {
        return Ok(await _service.RewardsMeta(filter));
    }

    /// <summary>
    /// Get one Reward
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Reward>> Reward([FromRoute()] RewardWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Reward(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Reward
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateReward(
        [FromRoute()] RewardWhereUniqueInput uniqueId,
        [FromQuery()] RewardUpdateInput rewardUpdateDto
    )
    {
        try
        {
            await _service.UpdateReward(uniqueId, rewardUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
