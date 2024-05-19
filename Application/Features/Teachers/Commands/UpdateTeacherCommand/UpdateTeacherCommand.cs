using Application.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using MediatR;

namespace Application.Features.Teachers.Commands.UpdateTeacherCommand
{
    public class UpdateTeacherCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UpdateHotelCommandHandler : IRequestHandler<UpdateTeacherCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Teacher> _repositoryAsync;

        public UpdateHotelCommandHandler(IRepositoryAsync<Teacher> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Response<int>> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
        {
            var record = await _repositoryAsync.GetByIdAsync(request.Id);
            if (record == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}.");
            }
            else
            {
                record.Name = request.Name;

                await _repositoryAsync.UpdateAsync(record);
            }

            return new Response<int>(record.Id);
        }
    }
}
