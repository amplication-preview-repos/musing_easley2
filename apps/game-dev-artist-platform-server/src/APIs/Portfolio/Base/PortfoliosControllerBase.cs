using GameDevArtistPlatform.APIs;
using GameDevArtistPlatform.APIs.Common;
using GameDevArtistPlatform.APIs.Dtos;
using GameDevArtistPlatform.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace GameDevArtistPlatform.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class PortfoliosControllerBase : ControllerBase
{
    protected readonly IPortfoliosService _service;

    public PortfoliosControllerBase(IPortfoliosService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Portfolio
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Portfolio>> CreatePortfolio(PortfolioCreateInput input)
    {
        var portfolio = await _service.CreatePortfolio(input);

        return CreatedAtAction(nameof(Portfolio), new { id = portfolio.Id }, portfolio);
    }

    /// <summary>
    /// Delete one Portfolio
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeletePortfolio(
        [FromRoute()] PortfolioWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeletePortfolio(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Portfolios
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Portfolio>>> Portfolios(
        [FromQuery()] PortfolioFindManyArgs filter
    )
    {
        return Ok(await _service.Portfolios(filter));
    }

    /// <summary>
    /// Meta data about Portfolio records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> PortfoliosMeta(
        [FromQuery()] PortfolioFindManyArgs filter
    )
    {
        return Ok(await _service.PortfoliosMeta(filter));
    }

    /// <summary>
    /// Get one Portfolio
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Portfolio>> Portfolio(
        [FromRoute()] PortfolioWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Portfolio(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Portfolio
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdatePortfolio(
        [FromRoute()] PortfolioWhereUniqueInput uniqueId,
        [FromQuery()] PortfolioUpdateInput portfolioUpdateDto
    )
    {
        try
        {
            await _service.UpdatePortfolio(uniqueId, portfolioUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
