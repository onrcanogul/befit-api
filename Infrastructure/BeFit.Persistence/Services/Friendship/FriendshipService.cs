using AutoMapper;
using BeFit.Application.Common;
using BeFit.Application.DataTransferObjects.Friendship;
using BeFit.Application.Repositories;
using BeFit.Application.Services.Friendship;
using BeFit.Domain.Entities.Enums;
using BeFit.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BeFit.Persistence.Services.Friendship
{
    public class FriendshipService(IRepository<Domain.Entities.Friendship> repository, IMapper mapper, IUnitOfWork uow) : IFriendshipService
    {
        public async Task<ServiceResponse<NoContent>> Send(FriendshipDto model)
        {
            var isExistingFriendship = repository.Any(f => f.SenderId == model.SenderId && f.ReceiverId == model.ReceiverId && 
                                                            (f.Status == FriendshipStatus.Pending || f.Status == FriendshipStatus.Accepted));
            if(isExistingFriendship)
                throw new BadRequestException("Friendship is already exist");
            var friendship = mapper.Map<Domain.Entities.Friendship>(model);
            await repository.CreateAsync(friendship);
            await uow.SaveChangesAsync();
            return ServiceResponse<NoContent>.Success(StatusCodes.Status201Created);
        }
        public async Task<ServiceResponse<NoContent>> Accept(string senderId, string receiverId)
        {
            var friendship = await repository.GetQueryable()
                .Where(f => f.SenderId == senderId 
                            && f.ReceiverId == receiverId
                            && f.Status != FriendshipStatus.Rejected)
                .FirstOrDefaultAsync() ?? throw new NotFoundException("Friendship not found");
            friendship.Status = FriendshipStatus.Accepted;
            repository.Update(friendship);
            await uow.SaveChangesAsync();
            return ServiceResponse<NoContent>.Success(StatusCodes.Status200OK);
        }
        public async Task<ServiceResponse<NoContent>> Reject(string senderId, string receiverId)
        {
            var friendship = await repository.GetQueryable()
                .Where(f => f.SenderId == senderId
                && f.ReceiverId == receiverId
                && f.Status != FriendshipStatus.Rejected)
                .FirstOrDefaultAsync() ?? throw new NotFoundException("Friendship not found");
            friendship.Status = FriendshipStatus.Rejected;
            repository.Update(friendship);
            await uow.SaveChangesAsync();
            return ServiceResponse<NoContent>.Success(StatusCodes.Status200OK);
        }
        public async Task<ServiceResponse<List<FriendshipDto>>> GetFriendshipsFromSender(string senderId)
        {
            var friendships = await repository.GetQueryable()
                .Where(f => f.SenderId == senderId && f.Status == FriendshipStatus.Accepted)
                .ToListAsync();
            var dto = mapper.Map<List<FriendshipDto>>(friendships);
            return ServiceResponse<List<FriendshipDto>>.Success(dto, StatusCodes.Status200OK);
        }
        public async Task<ServiceResponse<List<FriendshipDto>>> GetFriendshipsFromReceiver(string receiverId)
        {
            var friendships = await repository.GetQueryable()
                .Where(f => f.ReceiverId == receiverId && f.Status == FriendshipStatus.Accepted)
                .ToListAsync();
            var dto = mapper.Map<List<FriendshipDto>>(friendships);
            return ServiceResponse<List<FriendshipDto>>.Success(dto, StatusCodes.Status200OK);
        }
        public async Task<ServiceResponse<List<FriendshipDto>>> GetRejectedRequestsFromReceiver(string receiverId)
        {
            var friendships = await repository.GetQueryable()
                .Where(f => f.ReceiverId == receiverId && f.Status == FriendshipStatus.Rejected)
                .ToListAsync();
            var dto = mapper.Map<List<FriendshipDto>>(friendships);
            return ServiceResponse<List<FriendshipDto>>.Success(dto, StatusCodes.Status200OK);
        }
        public async Task<ServiceResponse<List<FriendshipDto>>> GetRejectedRequestsFromSender(string senderId)
        {
            var friendships = await repository.GetQueryable()
                .Where(f => f.SenderId == senderId && f.Status == FriendshipStatus.Rejected)
                .ToListAsync();
            var dto = mapper.Map<List<FriendshipDto>>(friendships);
            return ServiceResponse<List<FriendshipDto>>.Success(dto, StatusCodes.Status200OK);
        }
        public async Task<ServiceResponse<List<FriendshipDto>>> GetPendingRequestsFromReceiver(string receiverId)
        {
            var friendships = await repository.GetQueryable()
                .Where(f => f.ReceiverId == receiverId && f.Status == FriendshipStatus.Pending)
                .ToListAsync();
            var dto = mapper.Map<List<FriendshipDto>>(friendships);
            return ServiceResponse<List<FriendshipDto>>.Success(dto, StatusCodes.Status200OK);
        }
        public async Task<ServiceResponse<List<FriendshipDto>>> GetPendingRequestsFromSender(string senderId)
        {
            var friendships = await repository.GetQueryable()
                .Where(f => f.SenderId == senderId && f.Status == FriendshipStatus.Pending)
                .ToListAsync();
            var dto = mapper.Map<List<FriendshipDto>>(friendships);
            return ServiceResponse<List<FriendshipDto>>.Success(dto, StatusCodes.Status200OK);
        }
    }
}
