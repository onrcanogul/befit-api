using AutoMapper;
using BeFit.Application.Common;
using BeFit.Application.DataTransferObjects;
using BeFit.Application.DataTransferObjects.Post.CreateDtos;
using BeFit.Application.Repositories;
using BeFit.Application.Services.Post;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BeFit.Persistence.Services.Post
{
    public class PostService(IRepository<Domain.Entities.Post> repository, IUnitOfWork uow, IMapper mapper) : IPostService
    {
        public async Task<ServiceResponse<List<PostDto>>> Get(int page, int size)
        {
            var posts = await repository.GetQueryable()
                .Skip(page * size)
                .Take(size)
                    .Include(x => x.Likes)
                        .ThenInclude(x => x.User)
                    .Include(x => x.Dislikes)
                        .ThenInclude(x => x.User)
                    .Include(x => x.Comments)
                        .ThenInclude(x => x.User)
                    .Include(x => x.Images).ToListAsync();

            var dto = mapper.Map<List<PostDto>>(posts);

            return ServiceResponse<List<PostDto>>.Success(dto, StatusCodes.Status200OK);
        }
        public async Task<ServiceResponse<PostDto>> GetById(Guid id)
        {
            var post = await repository.GetByIdQueryable(id)
                    .Include(x => x.Likes)
                        .ThenInclude(x => x.User)
                    .Include(x => x.Dislikes)
                        .ThenInclude(x => x.User)
                    .Include(x => x.Comments)
                        .ThenInclude(x => x.User)
                    .Include(x => x.Images).ToListAsync();

            var dto = mapper.Map<PostDto>(post);

            return ServiceResponse<PostDto>.Success(dto, StatusCodes.Status200OK);
        }
        public async Task<ServiceResponse<List<PostDto>>> GetByUser(string id)
        {
            var posts = await repository.GetQueryable()
                .Where(x => x.UserId == id)
                   .Include(x => x.Likes)
                       .ThenInclude(x => x.User)
                   .Include(x => x.Dislikes)
                       .ThenInclude(x => x.User)
                   .Include(x => x.Comments)
                       .ThenInclude(x => x.User)
                   .Include(x => x.Images).ToListAsync();

            var dto = mapper.Map<List<PostDto>>(posts);

            return ServiceResponse<List<PostDto>>.Success(dto, StatusCodes.Status200OK);
        }
        public async Task<ServiceResponse<NoContent>> Create(CreatePostDto model)
        { 
            ArgumentNullException.ThrowIfNull(nameof(model));

            PostDto dto = new() { UserId = model.UserId, Title = model.Title, Description = model.Description }; 
            //image will seperate
            await repository.CreateAsync(mapper.Map<Domain.Entities.Post>(dto));
            await uow.SaveChangesAsync();

            return ServiceResponse<NoContent>.Success(StatusCodes.Status201Created);
        }
        public async Task<ServiceResponse<NoContent>> Update(UpdatePostDto model)
        {
            ArgumentNullException.ThrowIfNull(model);

            if (model.Id == Guid.Empty)
                return ServiceResponse<NoContent>.Failure("id is null or empty", StatusCodes.Status400BadRequest);

            var currentEntity = await repository.GetByIdQueryable(model.Id).FirstOrDefaultAsync()
                ?? throw new ArgumentNullException();

            currentEntity.Title = model.Title;
            currentEntity.Description = model.Description;

            repository.Update(currentEntity);
            await uow.SaveChangesAsync();

            return ServiceResponse<NoContent>.Success(StatusCodes.Status204NoContent);
        }

        public async Task<ServiceResponse<NoContent>> Delete(Guid id)
        {
            if (id == Guid.Empty)
                return ServiceResponse<NoContent>.Failure("id is null or empty", StatusCodes.Status400BadRequest);

            var currentEntity = await repository.GetByIdQueryable(id).FirstOrDefaultAsync() 
                ?? throw new ArgumentNullException();

            repository.Delete(currentEntity);
            await uow.SaveChangesAsync();

            return ServiceResponse<NoContent>.Success(StatusCodes.Status204NoContent);
        }

       

        


    }
}
