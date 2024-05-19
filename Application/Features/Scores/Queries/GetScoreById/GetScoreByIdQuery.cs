using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Scores.Queries.GetScoreById
{
    public class GetScoreByIdQuery : IRequest<Response<ScoreDto>>
    {
        public int Id { get; set; }

        public class GetAllScoresQueryHandler : IRequestHandler<GetScoreByIdQuery, Response<ScoreDto>>
        {
            private readonly IRepositoryAsync<Score> _repositoryAsync;
            private readonly IMapper _mapper;

            public GetAllScoresQueryHandler(IRepositoryAsync<Score> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<ScoreDto>> Handle(GetScoreByIdQuery request, CancellationToken cancellationToken)
            {
                var record = await _repositoryAsync.GetByIdAsync(request.Id);
                if (record == null)
                {
                    throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}.");
                }
                else
                {
                    var dto = _mapper.Map<ScoreDto>(record);
                    return new Response<ScoreDto>(dto);
                }
            }
        }
    }
}
