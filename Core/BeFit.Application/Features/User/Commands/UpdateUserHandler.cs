using System.Data.Common;
using BeFit.Application.Services;

namespace BeFit.Application.Features.User.Commands;

public record UpdateUserRequest(string Id,string Name, string Surname, int Age) : IRequest<UpdateUserResponse>;

public record UpdateUserResponse(ServiceResponse<NoContent> Response);

public class UpdateUserHandler(IUserService service) : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
{
    public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        return new(await service.Update(request.Id, request.Name, request.Surname, request.Age));
    }
}