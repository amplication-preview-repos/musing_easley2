using GameDevArtistPlatform.APIs;
using GameDevArtistPlatform.APIs.Common;
using GameDevArtistPlatform.APIs.Dtos;
using GameDevArtistPlatform.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace GameDevArtistPlatform.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class InstitutionsControllerBase : ControllerBase
{
    protected readonly IInstitutionsService _service;

    public InstitutionsControllerBase(IInstitutionsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Institution
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Institution>> CreateInstitution(InstitutionCreateInput input)
    {
        var institution = await _service.CreateInstitution(input);

        return CreatedAtAction(nameof(Institution), new { id = institution.Id }, institution);
    }

    /// <summary>
    /// Delete one Institution
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteInstitution(
        [FromRoute()] InstitutionWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteInstitution(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Institutions
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Institution>>> Institutions(
        [FromQuery()] InstitutionFindManyArgs filter
    )
    {
        return Ok(await _service.Institutions(filter));
    }

    /// <summary>
    /// Meta data about Institution records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> InstitutionsMeta(
        [FromQuery()] InstitutionFindManyArgs filter
    )
    {
        return Ok(await _service.InstitutionsMeta(filter));
    }

    /// <summary>
    /// Get one Institution
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Institution>> Institution(
        [FromRoute()] InstitutionWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Institution(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Institution
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateInstitution(
        [FromRoute()] InstitutionWhereUniqueInput uniqueId,
        [FromQuery()] InstitutionUpdateInput institutionUpdateDto
    )
    {
        try
        {
            await _service.UpdateInstitution(uniqueId, institutionUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
