using GameDevArtistPlatform.APIs;

namespace GameDevArtistPlatform;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IAnalyticsService, AnalyticsService>();
        services.AddScoped<ICompaniesService, CompaniesService>();
        services.AddScoped<IFeedbacksService, FeedbacksService>();
        services.AddScoped<IInstitutionsService, InstitutionsService>();
        services.AddScoped<ILearningPlansService, LearningPlansService>();
        services.AddScoped<IMentorProfilesService, MentorProfilesService>();
        services.AddScoped<IMockTestsService, MockTestsService>();
        services.AddScoped<IPortfoliosService, PortfoliosService>();
        services.AddScoped<IRewardsService, RewardsService>();
        services.AddScoped<IUsersService, UsersService>();
        services.AddScoped<IVendorsService, VendorsService>();
    }
}
