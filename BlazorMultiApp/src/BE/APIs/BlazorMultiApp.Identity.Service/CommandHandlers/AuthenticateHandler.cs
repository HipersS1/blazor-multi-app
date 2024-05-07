using BlazorMultiApp.Identity.Domain.Models;
using BlazorMultiApp.Identity.Service.Commands;
using BlazorMultiApp.Identity.Service.DTOs.Common;
using BlazorMultiApp.Identity.Service.Services.Interfaces;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BlazorMultiApp.Identity.Service.CommandHandlers
{
    public class AuthenticateHandler(SignInManager<User> signInManager, UserManager<User> userManager, IJwtService jwtService) 
        : IRequestHandler<AuthenticateCommand, Result<AuthorizationDto>>
    {
        public async Task<Result<AuthorizationDto>> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
            var signInResult = await signInManager.PasswordSignInAsync(request.AuthenticateRequestDto.Email, 
                request.AuthenticateRequestDto.Password, false, false);

            if (!signInResult.Succeeded)
            {
                return Result.Fail(new Error("Invalid credentials"));
            }

            var userResult = await userManager.FindByEmailAsync(request.AuthenticateRequestDto.Email);

            var authorizationDto = new AuthorizationDto(jwtService.GenerateAccessToken(userResult!), jwtService.GenerateRefreshToken());

            return Result.Ok(authorizationDto);
        }
    }
}
