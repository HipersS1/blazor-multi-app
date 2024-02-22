using BlazorMultiApp.Identity.Domain.Models;
using BlazorMultiApp.Identity.Service.Commands;
using BlazorMultiApp.Identity.Service.DTOs.Common;
using BlazorMultiApp.Identity.Service.Services.Interfaces;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BlazorMultiApp.Identity.Service.CommandHandlers
{
    public class AuthenticateHandler(SignInManager<User> SignInManager, UserManager<User> UserManager, IJwtService JwtService) 
        : IRequestHandler<AuthenticateCommand, Result<AuthorizationDto>>
    {
        public async Task<Result<AuthorizationDto>> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
            var signInResult = await SignInManager.PasswordSignInAsync(request.AuthenticateRequestDto.Email, request.AuthenticateRequestDto.Password, false, false);

            if (!signInResult.Succeeded)
            {
                return Result.Fail(new Error("Invalid credentials"));
            }

            var userResult = await UserManager.FindByEmailAsync(request.AuthenticateRequestDto.Email);
            var accessToken = JwtService.GenerateAccessToken(userResult!);

            return Result.Ok();
        }
    }
}
