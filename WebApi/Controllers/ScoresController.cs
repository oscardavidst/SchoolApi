using Application.Features.Scores.Commands.CreateScoreCommand;
using Application.Features.Scores.Commands.DeleteScoreCommand;
using Application.Features.Scores.Commands.UpdateScoreCommand;
using Application.Features.Scores.Queries.GetAllScores;
using Application.Features.Scores.Queries.GetScoreById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class ScoresController : BaseApiController
    {
        [Authorize(Roles = "Administrator,Basic")]
        [HttpGet()]
        public async Task<IActionResult> Get([FromQuery] GetAllScoresParameters filter) =>
            Ok(await Mediator.Send(new GetAllScoresQuery
            {
                Name = filter.Name,
                Value = filter.Value,
                IdStudent = filter.IdStudent,
                IdTeacher = filter.IdTeacher
            }));

        [Authorize(Roles = "Administrator,Basic")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) => Ok(await Mediator.Send(new GetScoreByIdQuery { Id = id }));

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> Post(CreateScoreCommand command) => Ok(await Mediator.Send(command));

        [Authorize(Roles = "Administrator")]
        [HttpPut]
        public async Task<IActionResult> Put(UpdateScoreCommand command) => Ok(await Mediator.Send(command));

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await Mediator.Send(new DeleteScoreCommand() { Id = id }));
    }
}
