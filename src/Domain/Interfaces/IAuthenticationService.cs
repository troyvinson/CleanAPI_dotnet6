using Domain.DataTransferObjects;
using Microsoft.AspNetCore.Identity;

namespace Domain.Interfaces
{
    internal interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration);
    }
}
