using System.Net;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
using Application.Exceptions;
using Application.Requests.BlockedCustomerRequest;
using Application.Responses.BlockedCustomerResponse;
using AutoMapper;
using Domain.Model;

namespace Application.Services;

public class BlockedCustomerService: BaseService<BlockedCustomerEntity, BlockedCustomerResponseModel, BlockedCustomerRequestModel>,IBlockedCustomerService
{
    private readonly IBlockedCustomerRepository _blockedCustomerRepository;
    private readonly IMapper _mapper;

    public BlockedCustomerService(IBlockedCustomerRepository repository, IMapper mapper) : base(repository, mapper)
    {
        _blockedCustomerRepository = repository;
        _mapper = mapper;
    }

    public override void Add(BlockedCustomerRequestModel request)
    {
        var parsedToCreate = request as CreateBlockedCustomerRequest;
        if (parsedToCreate==null)
        {
            throw new HttpStatusCodeException(HttpStatusCode.NotFound, nameof(BlockedCustomerEntity));
        }

        var mappedToResponse = _mapper.Map<CreateBlockedCustomerRequest, BlockedCustomerEntity>(parsedToCreate);
        _blockedCustomerRepository.Add(mappedToResponse);
        _blockedCustomerRepository.SaveChanges();
    }

    public override BlockedCustomerResponseModel GetById(int id)
    {
        var dbBlockedCustomer = _blockedCustomerRepository.FindById(id);
        if (dbBlockedCustomer==null)
        {
            throw new HttpStatusCodeException(HttpStatusCode.NotFound, nameof(BlockedCustomerEntity));
        }

        var mappedToResponse = _mapper.Map<BlockedCustomerEntity, BlockedCustomerResponseModel>(dbBlockedCustomer);
        return mappedToResponse;
    }

    public override IEnumerable<BlockedCustomerResponseModel> GetAll(int pageList, int pageNumber)
    {
        var dbBlockedCustomer = _blockedCustomerRepository.GetAll(pageList, pageNumber);
        var mappedToResponse =
            _mapper.Map<IEnumerable<BlockedCustomerEntity>, IEnumerable<BlockedCustomerResponseModel>>(
                dbBlockedCustomer);
        return mappedToResponse;
    }

    public override BlockedCustomerResponseModel Update(int id, BlockedCustomerRequestModel request)
    {
        var dbBlockedCustomer = _blockedCustomerRepository.FindById(id);
        if (dbBlockedCustomer==null)
        {
            throw new HttpStatusCodeException(HttpStatusCode.NotFound, nameof(BlockedCustomerEntity));
        }

        var blockedCustomerRequestToUpdate = request as UpdateBlockedCustomerRequest;
        var result = _mapper.Map(blockedCustomerRequestToUpdate, dbBlockedCustomer); 
        _blockedCustomerRepository.Update(dbBlockedCustomer);
        _blockedCustomerRepository.SaveChanges();
        return _mapper.Map<BlockedCustomerEntity, BlockedCustomerResponseModel>(dbBlockedCustomer);
    }

    public override bool Delete(int id)
    {
        var dbBlockedCustomer = _blockedCustomerRepository.FindById(id);
        if (dbBlockedCustomer==null)
        {
            throw new HttpStatusCodeException(HttpStatusCode.NotFound, nameof(BlockedCustomerEntity));
        }
        _blockedCustomerRepository.Delete(dbBlockedCustomer);
        _blockedCustomerRepository.SaveChanges();
        return true;
    }
}