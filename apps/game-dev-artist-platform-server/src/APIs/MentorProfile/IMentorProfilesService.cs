using GameDevArtistPlatform.APIs.Common;
using GameDevArtistPlatform.APIs.Dtos;

namespace GameDevArtistPlatform.APIs;

public interface IMentorProfilesService
{
    /// <summary>
    /// Create one MentorProfile
    /// </summary>
    public Task<MentorProfile> CreateMentorProfile(MentorProfileCreateInput mentorprofile);

    /// <summary>
    /// Delete one MentorProfile
    /// </summary>
    public Task DeleteMentorProfile(MentorProfileWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many MentorProfiles
    /// </summary>
    public Task<List<MentorProfile>> MentorProfiles(MentorProfileFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about MentorProfile records
    /// </summary>
    public Task<MetadataDto> MentorProfilesMeta(MentorProfileFindManyArgs findManyArgs);

    /// <summary>
    /// Get one MentorProfile
    /// </summary>
    public Task<MentorProfile> MentorProfile(MentorProfileWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one MentorProfile
    /// </summary>
    public Task UpdateMentorProfile(
        MentorProfileWhereUniqueInput uniqueId,
        MentorProfileUpdateInput updateDto
    );
}
