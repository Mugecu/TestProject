using Common.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tai.Authentications.DTO;
using TaiProgramms.DTO;
using TaiProgramms.Entities;

namespace Tai.Apis
{
    public class TaiProgrammApi
    {
        public void Register(WebApplication app)
        {
            app?.MapPost("api/programms", Create)
                .Produces<Guid>(StatusCodes.Status200OK)
                .WithName("CreateProgramm")
                .WithTags("Programm");

            app?.MapGet("api/programms/{programmId:Guid}", GetById)
                .Produces<UserDTO>(StatusCodes.Status200OK)
                .WithName("GetProgramm")
                .WithTags("Programm");

            app?.MapPut("api/programms/{programmId:Guid}", Update)
                .Produces<IResult>(StatusCodes.Status200OK)
                .WithName("UpdateProgramm")
                .WithTags("Programm");
        }

        [Authorize]
        private async Task<IResult> Create([FromBody] TaiProgrammDTO programmDto, Repository<TaiProgramm> programmRepository)
        {
            var createdUser = programmDto?.ToModel();

            var taiProgramm = await programmRepository.CreateAsync(createdUser);

            await programmRepository.SaveAsync();

            return taiProgramm is TaiProgramm
                ? Results.Ok(taiProgramm)
                : Results.BadRequest();
        }

        [Authorize]
        private async Task<IResult> GetById(Guid programmId, Repository<TaiProgramm> userRepository)
            => await userRepository.GetAsync(programmId) is TaiProgramm taiProgramm
                    ? Results.Ok(taiProgramm)
                    : Results.NotFound("Не существует.");

        [Authorize]
        private async Task<IResult> Update([FromRoute] Guid programmId, [FromBody] TaiProgrammDTO programmDto, Repository<TaiProgramm> programmRepository)
        {
            var taiProgrammUpdated = programmDto?.ToModel();

            if (taiProgrammUpdated is null) { return Results.BadRequest("Отсутствуют данные для обновления."); }

            var taiProgramm = await programmRepository.GetAsync(taiProgrammUpdated.Id);

            if (taiProgramm is null) { return Results.NotFound($@"Программа с идентификатором {taiProgrammUpdated.Id} отсутствует."); }

            taiProgramm.ChangeProgrammName(taiProgrammUpdated.Title.Name);
            taiProgramm.ChangeShortDescription(taiProgrammUpdated.ShortDescription.BriefDescription);
            taiProgramm.ChangeDescription(taiProgrammUpdated.Description.DescriptionText);

            await programmRepository.SaveAsync();

            return Results.Ok(taiProgramm);
        }
    }
}
