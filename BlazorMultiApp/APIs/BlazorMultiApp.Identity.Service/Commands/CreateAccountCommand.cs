using BlazorMultiApp.Identity.Service.DTOs.Request;
using FluentResults;
using MediatR;

namespace BlazorMultiApp.Identity.Service.Commands
{
    public record CreateAccountCommand(CreateUserRequestDto CreateUserRequestDto) : IRequest<Result<Guid>>;
}
