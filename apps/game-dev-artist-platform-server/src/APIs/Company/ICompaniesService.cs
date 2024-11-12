using GameDevArtistPlatform.APIs.Common;
using GameDevArtistPlatform.APIs.Dtos;

namespace GameDevArtistPlatform.APIs;

public interface ICompaniesService
{
    /// <summary>
    /// Create one Company
    /// </summary>
    public Task<Company> CreateCompany(CompanyCreateInput company);

    /// <summary>
    /// Delete one Company
    /// </summary>
    public Task DeleteCompany(CompanyWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Companies
    /// </summary>
    public Task<List<Company>> Companies(CompanyFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Company records
    /// </summary>
    public Task<MetadataDto> CompaniesMeta(CompanyFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Company
    /// </summary>
    public Task<Company> Company(CompanyWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Company
    /// </summary>
    public Task UpdateCompany(CompanyWhereUniqueInput uniqueId, CompanyUpdateInput updateDto);
}
