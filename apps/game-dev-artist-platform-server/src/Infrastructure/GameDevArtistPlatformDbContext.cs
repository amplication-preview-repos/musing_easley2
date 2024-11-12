using GameDevArtistPlatform.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace GameDevArtistPlatform.Infrastructure;

public class GameDevArtistPlatformDbContext : DbContext
{
    public GameDevArtistPlatformDbContext(DbContextOptions<GameDevArtistPlatformDbContext> options)
        : base(options) { }

    public DbSet<MentorProfileDbModel> MentorProfiles { get; set; }

    public DbSet<InstitutionDbModel> Institutions { get; set; }

    public DbSet<PortfolioDbModel> Portfolios { get; set; }

    public DbSet<CompanyDbModel> Companies { get; set; }

    public DbSet<VendorDbModel> Vendors { get; set; }

    public DbSet<RewardDbModel> Rewards { get; set; }

    public DbSet<AnalyticsDbModel> AnalyticsItems { get; set; }

    public DbSet<FeedbackDbModel> Feedbacks { get; set; }

    public DbSet<MockTestDbModel> MockTests { get; set; }

    public DbSet<LearningPlanDbModel> LearningPlans { get; set; }

    public DbSet<UserDbModel> Users { get; set; }
}
