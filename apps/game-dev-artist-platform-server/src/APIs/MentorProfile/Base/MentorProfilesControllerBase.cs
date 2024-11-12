using GameDevArtistPlatform.APIs;
using GameDevArtistPlatform.APIs.Common;
using GameDevArtistPlatform.APIs.Dtos;
using GameDevArtistPlatform.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace GameDevArtistPlatform.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class MentorProfilesControllerBase : ControllerBase
{
    protected readonly IMentorProfilesService _service;

    public MentorProfilesControllerBase(IMentorProfilesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one MentorProfile
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<MentorProfile>> CreateMentorProfile(
        MentorProfileCreateInput input
    )
    {
        var mentorProfile = await _service.CreateMentorProfile(input);

        return CreatedAtAction(nameof(MentorProfile), new { id = mentorProfile.Id }, mentorProfile);
    }

    /// <summary>
    /// Delete one MentorProfile
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteMentorProfile(
        [FromRoute()] MentorProfileWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteMentorProfile(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many MentorProfiles
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<MentorProfile>>> MentorProfiles(
        [FromQuery()] MentorProfileFindManyArgs filter
    )
    {
        return Ok(await _service.MentorProfiles(filter));
    }

    /// <summary>
    /// Meta data about MentorProfile records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> MentorProfilesMeta(
        [FromQuery()] MentorProfileFindManyArgs filter
    )
    {
        return Ok(await _service.MentorProfilesMeta(filter));
    }

    /// <summary>
    /// Get one MentorProfile
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<MentorProfile>> MentorProfile(
        [FromRoute()] MentorProfileWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.MentorProfile(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one MentorProfile
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateMentorProfile(
        [FromRoute()] MentorProfileWhereUniqueInput uniqueId,
        [FromQuery()] MentorProfileUpdateInput mentorProfileUpdateDto
    )
    {
        try
        {
            await _service.UpdateMentorProfile(uniqueId, mentorProfileUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
