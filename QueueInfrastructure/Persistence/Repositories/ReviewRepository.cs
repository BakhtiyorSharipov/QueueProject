using Application.Common.Interfaces.Repository;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using QueueInfrastructure.Persistence.DataBase;

namespace QueueInfrastructure.Persistence.Repositories;

public class ReviewRepository: Repository<ReviewEntity>, IReviewRepository
{
    private readonly DbSet<ReviewEntity> _dbReview;
    private readonly DbContext _context;

    public ReviewRepository(EFContext context) : base(context)
    {
        _dbReview = context.Set<ReviewEntity>();
        _context = context;
    }
}