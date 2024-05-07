using BlazorMultiApp.Identity.Service.DTOs.Common;
using BlazorMultiApp.Identity.Service.DTOs.Request;
using FluentResults;
using MediatR;

namespace BlazorMultiApp.Identity.Service.Commands
{
    public record AuthenticateCommand(AuthenticateRequest AuthenticateRequestDto) : IRequest<Result<AuthorizationDto>>;
}
