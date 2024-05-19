using Application.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using MediatR;

namespace Application.Features.Scores.Commands.DeleteScoreCommand
{
    public class DeleteScoreCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteScoreCommandHandler : IRequestHandler<DeleteScoreCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Score> _repositoryAsync;

        public DeleteScoreCommandHandler(IRepositoryAsync<Score> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Response<int>> Handle(DeleteScoreCommand request, CancellationToken cancellationToken)
        {
            var record = await _repositoryAsync.GetByIdAsync(request.Id);
            if (record == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}.");
            }
            else
            {
                await _repositoryAsync.DeleteAsync(record);
            }

            return new Response<int>(record.Id);
        }
    }
}
