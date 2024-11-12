using GameDevArtistPlatform.APIs.Common;
using GameDevArtistPlatform.APIs.Dtos;

namespace GameDevArtistPlatform.APIs;

public interface IMockTestsService
{
    /// <summary>
    /// Create one MockTest
    /// </summary>
    public Task<MockTest> CreateMockTest(MockTestCreateInput mocktest);

    /// <summary>
    /// Delete one MockTest
    /// </summary>
    public Task DeleteMockTest(MockTestWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many MockTests
    /// </summary>
    public Task<List<MockTest>> MockTests(MockTestFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about MockTest records
    /// </summary>
    public Task<MetadataDto> MockTestsMeta(MockTestFindManyArgs findManyArgs);

    /// <summary>
    /// Get one MockTest
    /// </summary>
    public Task<MockTest> MockTest(MockTestWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one MockTest
    /// </summary>
    public Task UpdateMockTest(MockTestWhereUniqueInput uniqueId, MockTestUpdateInput updateDto);
}
