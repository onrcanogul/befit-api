using BeFit.Application.Services;

namespace BeFit.Application.Features.User.Queries.GetById
{
    public record GetUserByIdRequest(string id) : IRequest<GetUserByIdResponse>;
    public record GetUserByIdResponse(ServiceResponse<UserDto> Response);
    
    public class GetUserByIdHandler(IUserService service) : IRequestHandler<GetUserByIdRequest, GetUserByIdResponse>
    {
        public async Task<GetUserByIdResponse> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            return new(await service.GetById(request.id));
        }
    }
}