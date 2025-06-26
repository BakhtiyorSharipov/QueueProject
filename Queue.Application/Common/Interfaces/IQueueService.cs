using Application.Requests.QueueRequest;
using Application.Responses.QueueResponse;
using Domain.Model;

namespace Application.Common.Interfaces;


public interface IQueueService: IBaseService<QueueEntity, QueueResponseModel, QueueRequestModel>
{
    
}