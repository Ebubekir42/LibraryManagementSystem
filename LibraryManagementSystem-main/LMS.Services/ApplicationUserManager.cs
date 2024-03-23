using LMS.Entities.Models;
using LMS.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using LMS.Entities.Dtos;
using AutoMapper;
using LMS.Repositories.Contracts;

namespace LMS.Services
{
    public class ApplicationUserManager : IApplicationUserService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _manager;
        public ApplicationUserManager(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, IMapper mapper, IRepositoryManager manager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
            _manager = manager;
        }
        
        public IEnumerable<IdentityRole> Roles => _roleManager.Roles;
        public async Task<IdentityResult> CreateOneUser(UserDtoForInsertion userDto)
        {
            var user = _mapper.Map<ApplicationUser>(userDto);
            var result = await _userManager.CreateAsync(user, user.Password);
            if (!result.Succeeded)
                throw new Exception("User could not be created.");
            if(userDto.Roles.Count > 0)
            {
                var roleResult = await _userManager.AddToRolesAsync(user, userDto.Roles);
                if (!roleResult.Succeeded)
                    throw new Exception("System have problems with roles");
            }
            return result;
        }
        public async Task<IdentityResult> CreateOneUser(RegisterDto registerDto)
        {
            var user = _mapper.Map<ApplicationUser>(registerDto);
            var result = await _userManager.CreateAsync(user, user.Password);
            if (!result.Succeeded)
                throw new Exception("User could not be created");
            var roleResult = await _userManager.AddToRolesAsync(user, new List<string>() { "User" });
            if (!roleResult.Succeeded)
                throw new Exception("System have problems with roles");
            _manager.Fine.CreateFine(new Fine() { ApplicationUserId = user.Id });
            _manager.Save();
            return result;
        }

        public async Task<IdentityResult> DeleteOneUser(string userName)
        {
            var user = await GetOneUserByUserName(userName);
            return await _userManager.DeleteAsync(user);
        }

        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            return _userManager.Users.ToList();
        }

        public async Task<ApplicationUser> GetOneUserByUserName(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            return user;
            //throw new Exception("User could not be found");
        }
        public async Task<ApplicationUser> GetOneUserByUserId(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return user;
        }

        public async Task Update(UserDtoForUpdate userDto)
        {
            var user = _mapper.Map<ApplicationUser>(userDto);
            var result = await _userManager.UpdateAsync(user);
            if (userDto?.Roles?.Count > 0)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, userRoles);
                await _userManager.AddToRolesAsync(user, userDto.Roles);
            }
        }
        public async Task<UserDtoForUpdate> GetOneUserDtoForUpdate(string userName)
        {
            var user = await GetOneUserByUserName(userName);
            var userDto = _mapper.Map<UserDtoForUpdate>(user);
            userDto.Roles = new HashSet<string>(Roles.Select(r => r.Name).ToList());
            userDto.UserRoles = new HashSet<string>(await _userManager.GetRolesAsync(user));
            return userDto;
        }
    }
}
