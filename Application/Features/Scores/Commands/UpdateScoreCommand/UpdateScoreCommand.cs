using Application.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using MediatR;

namespace Application.Features.Scores.Commands.UpdateScoreCommand
{
    public class UpdateScoreCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public int IdStudent { get; set; }
        public int IdTeacher { get; set; }
    }

    public class UpdateScoreCommandHandler : IRequestHandler<UpdateScoreCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Score> _repositoryAsync;

        public UpdateScoreCommandHandler(IRepositoryAsync<Score> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Response<int>> Handle(UpdateScoreCommand request, CancellationToken cancellationToken)
        {
            var record = await _repositoryAsync.GetByIdAsync(request.Id);
            if (record == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}.");
            }
            else
            {
                record.Name = request.Name;
                record.Value = request.Value;
                record.IdStudent = request.IdStudent;
                record.IdTeacher = request.IdTeacher;

                await _repositoryAsync.UpdateAsync(record);
            }

            return new Response<int>(record.Id);
        }
    }
}
