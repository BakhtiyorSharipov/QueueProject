using Application.Requests.ReviewRequest;
using Application.Responses.ReviewResponse;
using Domain.Model;

namespace Application.Common.Interfaces;


public interface IReviewService: IBaseService<ReviewEntity,ReviewResponseModel, ReviewRequestModel>
{
    
}