using GameDevArtistPlatform.APIs.Common;
using GameDevArtistPlatform.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameDevArtistPlatform.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class FeedbackFindManyArgs : FindManyInput<Feedback, FeedbackWhereInput> { }
