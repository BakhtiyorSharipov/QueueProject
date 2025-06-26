using System.Net;
using Application.Common.Interfaces.Repository;
using Application.Exceptions;
using Application.Requests.ReviewRequest;
using Application.Responses.ReviewResponse;
using AutoMapper;
using Domain.Model;

namespace Application.Services;

public class ReviewService: BaseService<ReviewEntity, ReviewResponseModel, ReviewRequestModel>
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IMapper _mapper;

    public ReviewService(IReviewRepository repository, IMapper mapper) : base(repository, mapper)
    {
        _reviewRepository = repository;
        _mapper = mapper;
    }

    public override void Add(ReviewRequestModel request)
    {
        var parsedToCreate = request as CreateReviewRequest;
        if (parsedToCreate==null)
        {
            throw new HttpStatusCodeException(HttpStatusCode.NotFound, nameof(ReviewEntity));
        }

        var mappedToReview = _mapper.Map<CreateReviewRequest, ReviewEntity>(parsedToCreate);
        _reviewRepository.Add(mappedToReview);
        _reviewRepository.SaveChanges();
    }

    public override ReviewResponseModel GetById(int id)
    {
        var dbReview = _reviewRepository.FindById(id);
        if (dbReview==null )
        {
            throw new HttpStatusCodeException(HttpStatusCode.NotFound, nameof(dbReview));
        }

        var mappedToResponse = _mapper.Map<ReviewEntity, ReviewResponseModel>(dbReview);
        return mappedToResponse;
    }

    public override IEnumerable<ReviewResponseModel> GetAll(int pageList, int pageNumber)
    {
        var dbReview = _reviewRepository.GetAll(pageList, pageNumber);
        var mappedToResponse = _mapper.Map<IEnumerable<ReviewEntity>, IEnumerable<ReviewResponseModel>>(dbReview);
        return mappedToResponse;
    }

    public override ReviewResponseModel Update(int id, ReviewRequestModel request)
    {
        var dbReview = _reviewRepository.FindById(id);
        if (dbReview==null)
        {
            throw new HttpStatusCodeException(HttpStatusCode.NotFound, nameof(ReviewEntity));
        }

        var reviewRequestToUpdate = request as UpdateReviewRequest;
        var result = _mapper.Map(reviewRequestToUpdate, dbReview);
        _reviewRepository.Update(dbReview);
        _reviewRepository.SaveChanges();
        return _mapper.Map<ReviewEntity, ReviewResponseModel>(dbReview);
    }

    public override bool Delete(int id)
    {
        var dbReview = _reviewRepository.FindById(id);
        if (dbReview==null)
        {
            throw new HttpStatusCodeException(HttpStatusCode.NotFound, nameof(ReviewEntity));
        }
        _reviewRepository.Delete(dbReview);
        _reviewRepository.SaveChanges();
        return true;
    }
}