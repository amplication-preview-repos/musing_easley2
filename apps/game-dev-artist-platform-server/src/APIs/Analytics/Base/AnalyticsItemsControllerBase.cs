using GameDevArtistPlatform.APIs;
using GameDevArtistPlatform.APIs.Common;
using GameDevArtistPlatform.APIs.Dtos;
using GameDevArtistPlatform.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace GameDevArtistPlatform.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class AnalyticsItemsControllerBase : ControllerBase
{
    protected readonly IAnalyticsItemsService _service;

    public AnalyticsItemsControllerBase(IAnalyticsItemsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Analytics
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Analytics>> CreateAnalytics(AnalyticsCreateInput input)
    {
        var analytics = await _service.CreateAnalytics(input);

        return CreatedAtAction(nameof(Analytics), new { id = analytics.Id }, analytics);
    }

    /// <summary>
    /// Delete one Analytics
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteAnalytics(
        [FromRoute()] AnalyticsWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteAnalytics(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many AnalyticsItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Analytics>>> AnalyticsItems(
        [FromQuery()] AnalyticsFindManyArgs filter
    )
    {
        return Ok(await _service.AnalyticsItems(filter));
    }

    /// <summary>
    /// Meta data about Analytics records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> AnalyticsItemsMeta(
        [FromQuery()] AnalyticsFindManyArgs filter
    )
    {
        return Ok(await _service.AnalyticsItemsMeta(filter));
    }

    /// <summary>
    /// Get one Analytics
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Analytics>> Analytics(
        [FromRoute()] AnalyticsWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Analytics(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Analytics
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateAnalytics(
        [FromRoute()] AnalyticsWhereUniqueInput uniqueId,
        [FromQuery()] AnalyticsUpdateInput analyticsUpdateDto
    )
    {
        try
        {
            await _service.UpdateAnalytics(uniqueId, analyticsUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
