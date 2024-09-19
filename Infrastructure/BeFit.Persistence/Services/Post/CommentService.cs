using AutoMapper;
using BeFit.Application.Common;
using BeFit.Application.DataTransferObjects;
using BeFit.Application.Repositories;
using BeFit.Application.Services.Post;
using BeFit.Domain.Entities;
using BeFit.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BeFit.Persistence.Services.Post
{
    public class CommentService(IRepository<Comment> repository, IMapper mapper, IUnitOfWork uow) : ICommentService
    {
        public async Task<ServiceResponse<List<CommentDto>>> GetByPost(Guid postId)
        {
            var comments = await repository.GetQueryable()
                .Where(x => x.PostId == postId)
                .Include(x => x.User)
                .Include(x => x.Likes)
                    .ThenInclude(x => x.User)
                .Include(x => x.Dislikes)
                    .ThenInclude(x => x.User)
                .ToListAsync();
            var dto = mapper.Map<List<CommentDto>>(comments);
            return ServiceResponse<List<CommentDto>>.Success(dto, StatusCodes.Status200OK);

        }
        public async Task<ServiceResponse<NoContent>> Create(string text, string userId, Guid postId)
        {
            Comment comment = new() { Text = text, PostId = postId , UserId = userId};
            await repository.CreateAsync(comment);
            await uow.SaveChangesAsync();
            return ServiceResponse<NoContent>.Success(StatusCodes.Status201Created);
        }
        public async Task<ServiceResponse<NoContent>> Update(string text, Guid Id)
        {
            if(Id == Guid.Empty || text == string.Empty)
                return ServiceResponse<NoContent>.Failure("bad request", StatusCodes.Status400BadRequest);
            var currentComment = await repository.GetByIdQueryable(Id).FirstOrDefaultAsync() ?? throw new ArgumentNullException();
            currentComment.Text = text;
            repository.Update(currentComment);
            await uow.SaveChangesAsync();
            return ServiceResponse<NoContent>.Success(StatusCodes.Status200OK);
        }
        public async Task<ServiceResponse<NoContent>> Delete(Guid id)
        {
            if(id == Guid.Empty)
                return ServiceResponse<NoContent>.Failure("bad request", StatusCodes.Status400BadRequest);
            var currentComment = await repository.GetByIdQueryable(id).FirstOrDefaultAsync() ?? throw new NotFoundException("comment not found");
            repository.Delete(currentComment);
            await uow.SaveChangesAsync();
            return ServiceResponse<NoContent>.Success(StatusCodes.Status200OK);
        }
    }
}
