using AutoMapper;
using BeFit.Application.Common;
using BeFit.Application.DataTransferObjects.Friendship;
using BeFit.Application.Repositories;

namespace BeFit.Persistence.Services.Friendship
{
    public class FriendshipService(IRepository<Domain.Entities.Friendship> repository, IMapper mapper, IUnitOfWork uow)
    {
        public Task<ServiceResponse<NoContent>> Send(FriendshipDto model)
        {
            var friendship = mapper.Map<Domain.Entities.Friendship>(model);

            throw new NotImplementedException();

        }
    }
}
