using BeFit.Application.Services.Identity;

namespace BeFit.Application.Features.UserProperties.Commands.Update
{
    public record UpdateUserPropertyRequest(UserPropertiesDto Model) : IRequest<UpdateUserPropertyResponse>;
    public record UpdateUserPropertyResponse(ServiceResponse<NoContent> Response);
    public class UpdateUserPropertyHandler(IUserPropertyService service) : IRequestHandler<UpdateUserPropertyRequest, UpdateUserPropertyResponse>
    {
        public async Task<UpdateUserPropertyResponse> Handle(UpdateUserPropertyRequest request, CancellationToken cancellationToken)
        {
            return new(await service.Update(request.Model));
        }
    }
}
