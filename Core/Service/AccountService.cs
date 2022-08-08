using System.Threading.Tasks;
using System.Security.Claims;
using DataBase.Entities;
using DataBase.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net;

namespace Core.Service
{
    public class AccountService
    {
        private readonly IUserRepository _userService;

        public AccountService(IUserRepository user)
        {
            _userService = user;
        }

        public async Task<BaseResponse<ClaimsIdentity>> Login(Login model)
        {
            try
            {
                var user = await _userService.GetUserList().FirstOrDefaultAsync(x => x.Name == model.Name);
                if(user == null)
                {
                    return new BaseResponse<ClaimsIdentity>() { Description = "Пользователь не найден" };
                }

                if (user.Password != model.Password)
                {
                    return new BaseResponse<ClaimsIdentity>() { Description = "Пароль неверен" };
                }

                var result = Authenticate(user);
                return new BaseResponse<ClaimsIdentity>()
                {
                    Data = result,
                    StatusCode = HttpStatusCode.OK
                };

            }
            catch
            {
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = "Уппс, что-то пошло не так"
                };
            }
        }

        private ClaimsIdentity Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Name),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
            };
            return new ClaimsIdentity(claims, "ApplicationCookie",
                ClaimsIdentity.DefaultRoleClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }
    }
}
