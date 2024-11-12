using GameDevArtistPlatform.APIs.Dtos;
using GameDevArtistPlatform.Infrastructure.Models;

namespace GameDevArtistPlatform.APIs.Extensions;

public static class LearningPlansExtensions
{
    public static LearningPlan ToDto(this LearningPlanDbModel model)
    {
        return new LearningPlan
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static LearningPlanDbModel ToModel(
        this LearningPlanUpdateInput updateDto,
        LearningPlanWhereUniqueInput uniqueId
    )
    {
        var learningPlan = new LearningPlanDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            learningPlan.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            learningPlan.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return learningPlan;
    }
}
