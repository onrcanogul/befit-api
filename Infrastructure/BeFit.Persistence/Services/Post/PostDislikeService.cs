using AutoMapper;
using BeFit.Application.Common;
using BeFit.Application.DataTransferObjects;
using BeFit.Application.Repositories;
using BeFit.Application.Services.Post;
using BeFit.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BeFit.Persistence.Services.Post
{
    public class PostDislikeService(IRepository<PostDislike> repository, IUnitOfWork uow, IMapper mapper) : IPostDislikeService
    {
        public async Task<ServiceResponse<NoContent>> Dislike(Guid postId, string userId)
        {
            var dislike = await repository.GetQueryable().Where(x => x.PostId == postId && x.UserId == userId).FirstOrDefaultAsync();
            if (dislike == null)
                await repository.CreateAsync(new() { Id = Guid.NewGuid(), PostId = postId, UserId = userId });
            else
                repository.Delete(dislike);
            await uow.SaveChangesAsync();
            return ServiceResponse<NoContent>.Success(StatusCodes.Status201Created);
        }
        public async Task<ServiceResponse<List<PostDislikeDto>>> GetByPost(Guid postId)
        {
            var dislikes = await repository.GetQueryable().Where(x => x.PostId == postId)
                .Include(x => x.User)
                .ToListAsync();
            var dto = mapper.Map<List<PostDislikeDto>>(dislikes);
            return ServiceResponse<List<PostDislikeDto>>.Success(dto, StatusCodes.Status200OK);
        }
    }
}
