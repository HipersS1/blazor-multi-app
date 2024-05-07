using BlazorMultiApp.Identity.Service.DTOs.Request;
using FluentResults;
using MediatR;

namespace BlazorMultiApp.Identity.Service.Commands
{
    public record CreateAccountCommand(CreateUserRequest CreateUserRequestDto) : IRequest<Result<Guid>>;
}
