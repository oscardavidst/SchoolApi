using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Teachers.Commands.CreateTeacherCommand
{
    public class CreateTeacherCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
    }

    public class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Teacher> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateTeacherCommandHandler(IRepositoryAsync<Teacher> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
        {
            var newRecord = _mapper.Map<Teacher>(request);
            var data = await _repositoryAsync.AddAsync(newRecord);

            return new Response<int>(data.Id);
        }
    }
}
