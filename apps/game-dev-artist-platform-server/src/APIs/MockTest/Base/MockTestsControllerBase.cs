using GameDevArtistPlatform.APIs;
using GameDevArtistPlatform.APIs.Common;
using GameDevArtistPlatform.APIs.Dtos;
using GameDevArtistPlatform.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace GameDevArtistPlatform.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class MockTestsControllerBase : ControllerBase
{
    protected readonly IMockTestsService _service;

    public MockTestsControllerBase(IMockTestsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one MockTest
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<MockTest>> CreateMockTest(MockTestCreateInput input)
    {
        var mockTest = await _service.CreateMockTest(input);

        return CreatedAtAction(nameof(MockTest), new { id = mockTest.Id }, mockTest);
    }

    /// <summary>
    /// Delete one MockTest
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteMockTest([FromRoute()] MockTestWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteMockTest(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many MockTests
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<MockTest>>> MockTests(
        [FromQuery()] MockTestFindManyArgs filter
    )
    {
        return Ok(await _service.MockTests(filter));
    }

    /// <summary>
    /// Meta data about MockTest records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> MockTestsMeta(
        [FromQuery()] MockTestFindManyArgs filter
    )
    {
        return Ok(await _service.MockTestsMeta(filter));
    }

    /// <summary>
    /// Get one MockTest
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<MockTest>> MockTest(
        [FromRoute()] MockTestWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.MockTest(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one MockTest
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateMockTest(
        [FromRoute()] MockTestWhereUniqueInput uniqueId,
        [FromQuery()] MockTestUpdateInput mockTestUpdateDto
    )
    {
        try
        {
            await _service.UpdateMockTest(uniqueId, mockTestUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
