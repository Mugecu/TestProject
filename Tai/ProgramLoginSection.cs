using Common.Entities;
using Microsoft.AspNetCore.Mvc;
using Tai.Authentications.DTO;
using Tai.Authentications.Entities;

namespace Tai
{
    public static partial class Program
    {
        public static WebApplication? AddLoginMaps(this WebApplication? web)
        {
            //добавить userDTO дабы пароль на светился на верх.
            web?.MapGet("api/authentications/login",  async ([FromBody] UserDTO userDto, Repository<User> repo)
                => new UserDTO().ToDto( await repo.GetAsync(userDto.ToModel().Id)) is UserDTO findedUser
                    ? Results.Ok("Autorize")
                    : Results.Unauthorized());

            return web;
        }
    }
}
