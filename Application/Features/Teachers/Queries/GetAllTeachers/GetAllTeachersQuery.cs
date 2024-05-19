using Application.DTOs;
using Application.Interfaces;
using Application.Specifications;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Teachers.Queries.GetAllTeachers
{
    public class GetAllTeachersQuery : IRequest<Response<List<TeacherDto>>>
    {
        public string Name { get; set; }

        public class GetAllTeachersQueryHandler : IRequestHandler<GetAllTeachersQuery, Response<List<TeacherDto>>>
        {
            private readonly IRepositoryAsync<Teacher> _repositoryAsync;
            private readonly IMapper _mapper;

            public GetAllTeachersQueryHandler(IRepositoryAsync<Teacher> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<List<TeacherDto>>> Handle(GetAllTeachersQuery request, CancellationToken cancellationToken)
            {
                var records = await _repositoryAsync.ListAsync(new TeachersSpecification(request.Name));
                var recordsDto = _mapper.Map<List<TeacherDto>>(records);
                return new Response<List<TeacherDto>>(recordsDto);
            }
        }
    }
}
