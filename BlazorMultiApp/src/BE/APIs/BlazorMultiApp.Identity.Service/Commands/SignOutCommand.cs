using FluentResults;
using MediatR;

namespace BlazorMultiApp.Identity.Service.Commands
{
    public class SignOutCommand() : IRequest<Result>;
}
