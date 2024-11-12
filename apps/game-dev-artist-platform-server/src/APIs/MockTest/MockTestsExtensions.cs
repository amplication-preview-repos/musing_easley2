using GameDevArtistPlatform.APIs.Dtos;
using GameDevArtistPlatform.Infrastructure.Models;

namespace GameDevArtistPlatform.APIs.Extensions;

public static class MockTestsExtensions
{
    public static MockTest ToDto(this MockTestDbModel model)
    {
        return new MockTest
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static MockTestDbModel ToModel(
        this MockTestUpdateInput updateDto,
        MockTestWhereUniqueInput uniqueId
    )
    {
        var mockTest = new MockTestDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            mockTest.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            mockTest.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return mockTest;
    }
}
