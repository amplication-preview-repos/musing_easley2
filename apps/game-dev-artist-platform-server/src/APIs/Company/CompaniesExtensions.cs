using GameDevArtistPlatform.APIs.Dtos;
using GameDevArtistPlatform.Infrastructure.Models;

namespace GameDevArtistPlatform.APIs.Extensions;

public static class CompaniesExtensions
{
    public static Company ToDto(this CompanyDbModel model)
    {
        return new Company
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static CompanyDbModel ToModel(
        this CompanyUpdateInput updateDto,
        CompanyWhereUniqueInput uniqueId
    )
    {
        var company = new CompanyDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            company.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            company.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return company;
    }
}
