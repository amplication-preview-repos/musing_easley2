using GameDevArtistPlatform.APIs.Common;
using GameDevArtistPlatform.APIs.Dtos;

namespace GameDevArtistPlatform.APIs;

public interface ILearningPlansService
{
    /// <summary>
    /// Create one LearningPlan
    /// </summary>
    public Task<LearningPlan> CreateLearningPlan(LearningPlanCreateInput learningplan);

    /// <summary>
    /// Delete one LearningPlan
    /// </summary>
    public Task DeleteLearningPlan(LearningPlanWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many LearningPlans
    /// </summary>
    public Task<List<LearningPlan>> LearningPlans(LearningPlanFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about LearningPlan records
    /// </summary>
    public Task<MetadataDto> LearningPlansMeta(LearningPlanFindManyArgs findManyArgs);

    /// <summary>
    /// Get one LearningPlan
    /// </summary>
    public Task<LearningPlan> LearningPlan(LearningPlanWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one LearningPlan
    /// </summary>
    public Task UpdateLearningPlan(
        LearningPlanWhereUniqueInput uniqueId,
        LearningPlanUpdateInput updateDto
    );
}
