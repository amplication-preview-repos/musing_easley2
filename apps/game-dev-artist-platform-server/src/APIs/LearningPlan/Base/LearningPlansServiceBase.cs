using GameDevArtistPlatform.APIs;
using GameDevArtistPlatform.APIs.Common;
using GameDevArtistPlatform.APIs.Dtos;
using GameDevArtistPlatform.APIs.Errors;
using GameDevArtistPlatform.APIs.Extensions;
using GameDevArtistPlatform.Infrastructure;
using GameDevArtistPlatform.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace GameDevArtistPlatform.APIs;

public abstract class LearningPlansServiceBase : ILearningPlansService
{
    protected readonly GameDevArtistPlatformDbContext _context;

    public LearningPlansServiceBase(GameDevArtistPlatformDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one LearningPlan
    /// </summary>
    public async Task<LearningPlan> CreateLearningPlan(LearningPlanCreateInput createDto)
    {
        var learningPlan = new LearningPlanDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            learningPlan.Id = createDto.Id;
        }

        _context.LearningPlans.Add(learningPlan);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<LearningPlanDbModel>(learningPlan.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one LearningPlan
    /// </summary>
    public async Task DeleteLearningPlan(LearningPlanWhereUniqueInput uniqueId)
    {
        var learningPlan = await _context.LearningPlans.FindAsync(uniqueId.Id);
        if (learningPlan == null)
        {
            throw new NotFoundException();
        }

        _context.LearningPlans.Remove(learningPlan);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many LearningPlans
    /// </summary>
    public async Task<List<LearningPlan>> LearningPlans(LearningPlanFindManyArgs findManyArgs)
    {
        var learningPlans = await _context
            .LearningPlans.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return learningPlans.ConvertAll(learningPlan => learningPlan.ToDto());
    }

    /// <summary>
    /// Meta data about LearningPlan records
    /// </summary>
    public async Task<MetadataDto> LearningPlansMeta(LearningPlanFindManyArgs findManyArgs)
    {
        var count = await _context.LearningPlans.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one LearningPlan
    /// </summary>
    public async Task<LearningPlan> LearningPlan(LearningPlanWhereUniqueInput uniqueId)
    {
        var learningPlans = await this.LearningPlans(
            new LearningPlanFindManyArgs { Where = new LearningPlanWhereInput { Id = uniqueId.Id } }
        );
        var learningPlan = learningPlans.FirstOrDefault();
        if (learningPlan == null)
        {
            throw new NotFoundException();
        }

        return learningPlan;
    }

    /// <summary>
    /// Update one LearningPlan
    /// </summary>
    public async Task UpdateLearningPlan(
        LearningPlanWhereUniqueInput uniqueId,
        LearningPlanUpdateInput updateDto
    )
    {
        var learningPlan = updateDto.ToModel(uniqueId);

        _context.Entry(learningPlan).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.LearningPlans.Any(e => e.Id == learningPlan.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
