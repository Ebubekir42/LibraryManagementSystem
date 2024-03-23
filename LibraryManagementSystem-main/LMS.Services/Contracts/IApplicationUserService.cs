using LMS.Entities.Models;
using Microsoft.AspNetCore.Identity;
using LMS.Entities.Dtos;

namespace LMS.Services.Contracts
{
    public interface IApplicationUserService
    {
        IEnumerable<IdentityRole> Roles { get; }
        IEnumerable<ApplicationUser> GetAllUsers();
        Task<IdentityResult> CreateOneUser(UserDtoForInsertion userDto);
        Task<IdentityResult> CreateOneUser(RegisterDto registerDto);
        Task<ApplicationUser> GetOneUserByUserName(string userName);
        Task<IdentityResult> DeleteOneUser(string identityNumber);
        Task Update(UserDtoForUpdate userDto);
        Task<UserDtoForUpdate> GetOneUserDtoForUpdate(string userName);
        Task<ApplicationUser> GetOneUserByUserId(string userId);
    }
}
