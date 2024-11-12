using GameDevArtistPlatform.APIs;
using GameDevArtistPlatform.APIs.Common;
using GameDevArtistPlatform.APIs.Dtos;
using GameDevArtistPlatform.APIs.Errors;
using GameDevArtistPlatform.APIs.Extensions;
using GameDevArtistPlatform.Infrastructure;
using GameDevArtistPlatform.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace GameDevArtistPlatform.APIs;

public abstract class MentorProfilesServiceBase : IMentorProfilesService
{
    protected readonly GameDevArtistPlatformDbContext _context;

    public MentorProfilesServiceBase(GameDevArtistPlatformDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one MentorProfile
    /// </summary>
    public async Task<MentorProfile> CreateMentorProfile(MentorProfileCreateInput createDto)
    {
        var mentorProfile = new MentorProfileDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            mentorProfile.Id = createDto.Id;
        }

        _context.MentorProfiles.Add(mentorProfile);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<MentorProfileDbModel>(mentorProfile.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one MentorProfile
    /// </summary>
    public async Task DeleteMentorProfile(MentorProfileWhereUniqueInput uniqueId)
    {
        var mentorProfile = await _context.MentorProfiles.FindAsync(uniqueId.Id);
        if (mentorProfile == null)
        {
            throw new NotFoundException();
        }

        _context.MentorProfiles.Remove(mentorProfile);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many MentorProfiles
    /// </summary>
    public async Task<List<MentorProfile>> MentorProfiles(MentorProfileFindManyArgs findManyArgs)
    {
        var mentorProfiles = await _context
            .MentorProfiles.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return mentorProfiles.ConvertAll(mentorProfile => mentorProfile.ToDto());
    }

    /// <summary>
    /// Meta data about MentorProfile records
    /// </summary>
    public async Task<MetadataDto> MentorProfilesMeta(MentorProfileFindManyArgs findManyArgs)
    {
        var count = await _context.MentorProfiles.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one MentorProfile
    /// </summary>
    public async Task<MentorProfile> MentorProfile(MentorProfileWhereUniqueInput uniqueId)
    {
        var mentorProfiles = await this.MentorProfiles(
            new MentorProfileFindManyArgs
            {
                Where = new MentorProfileWhereInput { Id = uniqueId.Id }
            }
        );
        var mentorProfile = mentorProfiles.FirstOrDefault();
        if (mentorProfile == null)
        {
            throw new NotFoundException();
        }

        return mentorProfile;
    }

    /// <summary>
    /// Update one MentorProfile
    /// </summary>
    public async Task UpdateMentorProfile(
        MentorProfileWhereUniqueInput uniqueId,
        MentorProfileUpdateInput updateDto
    )
    {
        var mentorProfile = updateDto.ToModel(uniqueId);

        _context.Entry(mentorProfile).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.MentorProfiles.Any(e => e.Id == mentorProfile.Id))
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
