using GameDevArtistPlatform.APIs;
using GameDevArtistPlatform.APIs.Common;
using GameDevArtistPlatform.APIs.Dtos;
using GameDevArtistPlatform.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace GameDevArtistPlatform.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class CompaniesControllerBase : ControllerBase
{
    protected readonly ICompaniesService _service;

    public CompaniesControllerBase(ICompaniesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Company
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Company>> CreateCompany(CompanyCreateInput input)
    {
        var company = await _service.CreateCompany(input);

        return CreatedAtAction(nameof(Company), new { id = company.Id }, company);
    }

    /// <summary>
    /// Delete one Company
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteCompany([FromRoute()] CompanyWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteCompany(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Companies
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Company>>> Companies(
        [FromQuery()] CompanyFindManyArgs filter
    )
    {
        return Ok(await _service.Companies(filter));
    }

    /// <summary>
    /// Meta data about Company records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> CompaniesMeta(
        [FromQuery()] CompanyFindManyArgs filter
    )
    {
        return Ok(await _service.CompaniesMeta(filter));
    }

    /// <summary>
    /// Get one Company
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Company>> Company([FromRoute()] CompanyWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Company(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Company
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateCompany(
        [FromRoute()] CompanyWhereUniqueInput uniqueId,
        [FromQuery()] CompanyUpdateInput companyUpdateDto
    )
    {
        try
        {
            await _service.UpdateCompany(uniqueId, companyUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
