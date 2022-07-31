using System.Threading.Tasks;
using System.Security.Claims;
using Test.Models.ModelsDB.Entities;
using Test.Models.ModelsDB.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Test.Models.ModelsDB.ServicesImpl
{
    public class AccountService
    {
        private readonly IUser _userService;

        public AccountService(IUser user)
        {
            _userService = user;
        }

        public async Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model)
        {
            try
            {
                var user = await _userService.GetObjectListAsyn().FirstOrDefaultAsync(x => x.Name == model.Name);
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
                    StatusCode = Enum.StatusCode.OK
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
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Id.ToString()),
            };
            return new ClaimsIdentity(claims, "ApplicationCookie",
                ClaimsIdentity.DefaultRoleClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }
    }
}
