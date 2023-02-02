using IdentityServer4.Context;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Validation;

namespace IdentiyServer4
{
    public class UserPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly ApplicationContext _context;

        public UserPasswordValidator(ApplicationContext context)
        {
            _context = context;
        }

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var user = _context.Users.FirstOrDefault(f => f.Email == context.UserName && f.Password == HashPasswordService.HashPassword(context.Password));

            if (user != null)
            {
                context.Result = new GrantValidationResult(user.Email, "pwd");
                return Task.CompletedTask;
            }

            context.Result = new GrantValidationResult(TokenRequestErrors.UnauthorizedClient, "Invalid Credentials");
            return Task.CompletedTask;
        }
    }
}
