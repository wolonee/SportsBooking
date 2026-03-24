using CSharpFunctionalExtensions;
using SportsBooking.Contracts.Facility;
using SportsBooking.Contracts.Facility.Dtos;
using SportsBooking.Contracts.Review;
using SportsBooking.Shared;

namespace SportsBooking.Application.Facilities;

public interface IFacilitiesService
{
    /// <summary>
    /// Создание вопроса
    /// </summary>
    /// <param name="facilityDto">DTO для создания спорт площадки.</param>
    /// <param name="cancellationToken">Токен отмены асинронной операции.</param>
    /// <returns>Результат работы метода - либо ID созданной спорт площадки, либо список ошибок.</returns>
    Task<Result<Guid, Failure>> Create(CreateFacilityDto facilityDto, CancellationToken cancellationToken);
    
    Task<Result<Guid, Failure>> AddReview(Guid id, AddReviewDto reviewDto, CancellationToken cancellationToken);
    
    Task GetAll(CancellationToken cancellationToken);
    
    Task GetById(Guid id, CancellationToken cancellationToken);
    
    Task GetReviews(Guid id, CancellationToken cancellationToken);
}