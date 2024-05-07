using BlazorMultiApp.Identity.Domain.Models;
using BlazorMultiApp.Identity.Service.Commands;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BlazorMultiApp.Identity.Service.CommandHandlers
{
    public class SignOutHandler(SignInManager<User> signInManager) : IRequestHandler<SignOutCommand, Result>
    {
        public async Task<Result> Handle(SignOutCommand request, CancellationToken cancellationToken)
        {
            await signInManager.SignOutAsync();

            return Result.Ok();
        }
    }
}
