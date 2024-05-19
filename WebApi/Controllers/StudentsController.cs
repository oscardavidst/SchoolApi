using Application.Features.Students.Commands.CreateStudentCommand;
using Application.Features.Students.Commands.DeleteStudentCommand;
using Application.Features.Students.Commands.UpdateStudentCommand;
using Application.Features.Students.Queries.GetAllStudents;
using Application.Features.Students.Queries.GetStudentById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class StudentsController : BaseApiController
    {
        [Authorize(Roles = "Administrator,Basic")]
        [HttpGet()]
        public async Task<IActionResult> Get([FromQuery] GetAllStudentsParameters filter) =>
            Ok(await Mediator.Send(new GetAllStudentsQuery { Name = filter.Name }));

        [Authorize(Roles = "Administrator,Basic")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) => Ok(await Mediator.Send(new GetStudentByIdQuery { Id = id }));

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> Post(CreateStudentCommand command) => Ok(await Mediator.Send(command));

        [Authorize(Roles = "Administrator")]
        [HttpPut]
        public async Task<IActionResult> Put(UpdateStudentCommand command) => Ok(await Mediator.Send(command));

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await Mediator.Send(new DeleteStudentCommand() { Id = id }));
    }
}
