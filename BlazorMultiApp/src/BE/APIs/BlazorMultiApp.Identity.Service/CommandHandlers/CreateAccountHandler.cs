using BlazorMultiApp.Identity.Domain.Models;
using BlazorMultiApp.Identity.Service.Commands;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BlazorMultiApp.Identity.Service.CommandHandlers
{
    public class CreateAccountHandler : IRequestHandler<CreateAccountCommand, Result<Guid>>
    {
        private readonly UserManager<User> _userManager;

        public CreateAccountHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Result<Guid>> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            User user = new User
            {
                FirstName = request.CreateUserRequestDto.FirstName,
                LastName = request.CreateUserRequestDto.LastName,
                MiddleName = request.CreateUserRequestDto.MiddleName,
                Email = request.CreateUserRequestDto.Email,
                UserName = request.CreateUserRequestDto.Email
            };

            var result = await _userManager.CreateAsync(user, request.CreateUserRequestDto.Password);

            return result.Succeeded ? Result.Ok(user.Id) : Result.Fail(new Error(result.Errors.First().Description));
        }
    }
}
