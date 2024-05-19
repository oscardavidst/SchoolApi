using Application.Features.Teachers.Commands.CreateTeacherCommand;
using Application.Features.Teachers.Commands.DeleteTeacherCommand;
using Application.Features.Teachers.Commands.UpdateTeacherCommand;
using Application.Features.Teachers.Queries.GetAllTeachers;
using Application.Features.Teachers.Queries.GetTeacherById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class TeachersController : BaseApiController
    {
        [Authorize(Roles = "Administrator,Basic")]
        [HttpGet()]
        public async Task<IActionResult> Get([FromQuery] GetAllTeachersParameters filter) =>
            Ok(await Mediator.Send(new GetAllTeachersQuery { Name = filter.Name }));

        [Authorize(Roles = "Administrator,Basic")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) => Ok(await Mediator.Send(new GetTeacherByIdQuery { Id = id }));

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> Post(CreateTeacherCommand command) => Ok(await Mediator.Send(command));

        [Authorize(Roles = "Administrator")]
        [HttpPut]
        public async Task<IActionResult> Put(UpdateTeacherCommand command) => Ok(await Mediator.Send(command));

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await Mediator.Send(new DeleteTeacherCommand() { Id = id }));
    }
}
