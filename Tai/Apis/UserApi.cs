using Common.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tai.Authentications.DTO;
using Tai.Authentications.Entities;
using Tai.Authentications.Interfaces;

namespace Tai.Apis
{
    public class UserApi
    {
        private readonly IDateTime _dateTime;

        public UserApi(IDateTime dateTime)
            => _dateTime = dateTime;

        public void Register(WebApplication app)
        {

            app?.MapPost("api/users", Create)
                .Produces<Guid>(StatusCodes.Status200OK)
                .WithName("CreateUser")
                .WithTags("Users");

            app?.MapGet("api/users/{userId:Guid}", GetById)
                .Produces<UserDTO>(StatusCodes.Status200OK)
                .WithName("GetUser")
                .WithTags("Users");

            app?.MapPut("api/users/{userId:Guid}", Update)
                .Produces<IResult>(StatusCodes.Status200OK)
                .WithName("UpdateUser")
                .WithTags("Users");
        }

        private async Task<IResult> Create([FromBody] UserDTO userDto, Repository<User> userRepository)
        {
            var createdUser = userDto.ToModel();

            if (createdUser.TimeStamp == null)
                createdUser.SetTimeStamp(_dateTime);

            var user = await userRepository.CreateAsync(createdUser);

            await userRepository.SaveAsync();

            return user is not null 
                ? Results.Ok(user)
                : Results.BadRequest();
        }

        private async Task<IResult> GetById(Guid id, Repository<User> userRepository)
            => await userRepository.GetAsync(id) is User user
                    ? Results.Ok(new UserDTO().ToDto(user))
                    : Results.NotFound("Не существует.");

        [Authorize]
        private async Task<IResult> Update([FromRoute] Guid userId, [FromBody] UserDTO userDto, Repository<User> userRepository)
        {
            var updatedUser = userDto?.ToModel();

            if (updatedUser is null) { return Results.BadRequest("Отсутствуют данные для обновления."); }

            var user = await userRepository.GetAsync(updatedUser.Id);

            if (user is null) { return Results.NotFound($@"Пользователь с идентификатором {updatedUser.Id} отсутствует."); }

            user.RenameUser(updatedUser.UserNameSurname.Name, updatedUser.UserNameSurname.Surname);
            user.ChangeUserEmail(updatedUser.UserEmail.EmailName, updatedUser.UserEmail.DomainName);
            user.ChangeUserLogin(updatedUser.UserLogin.Login);

            if (updatedUser.TimeStamp != null) { user.TimeStamp.SetUpdateAt(_dateTime.Now); }

            await userRepository.SaveAsync();

            return Results.Ok(user);
        }
    }
}
