using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Scores.Commands.CreateScoreCommand
{
    public class CreateScoreCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public int IdStudent { get; set; }
        public int IdTeacher { get; set; }
    }

    public class CreateScoreCommandHandler : IRequestHandler<CreateScoreCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Score> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateScoreCommandHandler(IRepositoryAsync<Score> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateScoreCommand request, CancellationToken cancellationToken)
        {
            var newRecord = _mapper.Map<Score>(request);
            var data = await _repositoryAsync.AddAsync(newRecord);

            return new Response<int>(data.Id);
        }
    }
}
