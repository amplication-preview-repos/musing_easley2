using GameDevArtistPlatform.APIs.Common;
using GameDevArtistPlatform.APIs.Dtos;

namespace GameDevArtistPlatform.APIs;

public interface IInstitutionsService
{
    /// <summary>
    /// Create one Institution
    /// </summary>
    public Task<Institution> CreateInstitution(InstitutionCreateInput institution);

    /// <summary>
    /// Delete one Institution
    /// </summary>
    public Task DeleteInstitution(InstitutionWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Institutions
    /// </summary>
    public Task<List<Institution>> Institutions(InstitutionFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Institution records
    /// </summary>
    public Task<MetadataDto> InstitutionsMeta(InstitutionFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Institution
    /// </summary>
    public Task<Institution> Institution(InstitutionWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Institution
    /// </summary>
    public Task UpdateInstitution(
        InstitutionWhereUniqueInput uniqueId,
        InstitutionUpdateInput updateDto
    );
}
