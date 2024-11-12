using GameDevArtistPlatform.APIs;
using GameDevArtistPlatform.APIs.Common;
using GameDevArtistPlatform.APIs.Dtos;
using GameDevArtistPlatform.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace GameDevArtistPlatform.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class LearningPlansControllerBase : ControllerBase
{
    protected readonly ILearningPlansService _service;

    public LearningPlansControllerBase(ILearningPlansService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one LearningPlan
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<LearningPlan>> CreateLearningPlan(LearningPlanCreateInput input)
    {
        var learningPlan = await _service.CreateLearningPlan(input);

        return CreatedAtAction(nameof(LearningPlan), new { id = learningPlan.Id }, learningPlan);
    }

    /// <summary>
    /// Delete one LearningPlan
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteLearningPlan(
        [FromRoute()] LearningPlanWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteLearningPlan(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many LearningPlans
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<LearningPlan>>> LearningPlans(
        [FromQuery()] LearningPlanFindManyArgs filter
    )
    {
        return Ok(await _service.LearningPlans(filter));
    }

    /// <summary>
    /// Meta data about LearningPlan records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> LearningPlansMeta(
        [FromQuery()] LearningPlanFindManyArgs filter
    )
    {
        return Ok(await _service.LearningPlansMeta(filter));
    }

    /// <summary>
    /// Get one LearningPlan
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<LearningPlan>> LearningPlan(
        [FromRoute()] LearningPlanWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.LearningPlan(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one LearningPlan
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateLearningPlan(
        [FromRoute()] LearningPlanWhereUniqueInput uniqueId,
        [FromQuery()] LearningPlanUpdateInput learningPlanUpdateDto
    )
    {
        try
        {
            await _service.UpdateLearningPlan(uniqueId, learningPlanUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
