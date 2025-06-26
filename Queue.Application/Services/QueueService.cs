using System.Net;
using System.Net.Mime;
using Application.Common.Interfaces.Repository;
using Application.Exceptions;
using Application.Requests.QueueRequest;
using Application.Responses.QueueResponse;
using AutoMapper;
using Domain.Model;

namespace Application.Services;

public class QueueService: BaseService<QueueEntity, QueueResponseModel, QueueRequestModel>
{
    private readonly IQueueRepository _queueRepository;
    private readonly IMapper _mapper;

    public QueueService(IQueueRepository repository, IMapper mapper) : base(repository, mapper)
    {
        _queueRepository = repository;
        _mapper = mapper;
    }

    public override void Add(QueueRequestModel request)
    {
        var parsedToCreate = request as CreateQueueRequest;
        if (parsedToCreate==null)
        {
            throw new HttpStatusCodeException(HttpStatusCode.NotFound, nameof(QueueEntity));
        }

        var mappedToQueue = _mapper.Map<CreateQueueRequest, QueueEntity>(parsedToCreate);
        _queueRepository.Add(mappedToQueue);
        _queueRepository.SaveChanges();
    }

    public override QueueResponseModel GetById(int id)
    {
        var dbQueue = _queueRepository.FindById(id);
        if (dbQueue==null)
        {
            throw new HttpStatusCodeException(HttpStatusCode.NotFound, nameof(QueueEntity));
        }

        var mappedToResponse = _mapper.Map<QueueEntity, QueueResponseModel>(dbQueue);
        return mappedToResponse;
    }

    public override IEnumerable<QueueResponseModel> GetAll(int pageList, int pageNumber)
    {
        var dbQueue = _queueRepository.GetAll(pageList, pageNumber);
        var mappedToResponse = _mapper.Map<IEnumerable<QueueEntity>, IEnumerable<QueueResponseModel>>(dbQueue);
        return mappedToResponse;
    }

    public override QueueResponseModel Update(int id, QueueRequestModel request)
    {
        var dbQueue = _queueRepository.FindById(id);
        if (dbQueue==null)
        {
            throw new HttpStatusCodeException(HttpStatusCode.NotFound, nameof(QueueEntity));
        }

        var queueRequestToUpdate = request as UpdateQueueRequest;
        var result = _mapper.Map(queueRequestToUpdate, dbQueue);
        _queueRepository.Update(dbQueue);
        _queueRepository.SaveChanges();
        return _mapper.Map<QueueEntity, QueueResponseModel>(dbQueue);
    }

    public override bool Delete(int id)
    {
        var dbQueue = _queueRepository.FindById(id);
        if (dbQueue==null)
        {
            throw new HttpStatusCodeException(HttpStatusCode.NotFound, nameof(QueueEntity));
        }
        
        _queueRepository.Delete(dbQueue);
        _queueRepository.SaveChanges();
        return true;
    }
}