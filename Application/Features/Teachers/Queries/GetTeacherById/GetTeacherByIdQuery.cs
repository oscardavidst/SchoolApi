using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Teachers.Queries.GetTeacherById
{
    public class GetTeacherByIdQuery : IRequest<Response<TeacherDto>>
    {
        public int Id { get; set; }

        public class GetAllTeachersQueryHandler : IRequestHandler<GetTeacherByIdQuery, Response<TeacherDto>>
        {
            private readonly IRepositoryAsync<Teacher> _repositoryAsync;
            private readonly IMapper _mapper;

            public GetAllTeachersQueryHandler(IRepositoryAsync<Teacher> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<TeacherDto>> Handle(GetTeacherByIdQuery request, CancellationToken cancellationToken)
            {
                var record = await _repositoryAsync.GetByIdAsync(request.Id);
                if (record == null)
                {
                    throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}.");
                }
                else
                {
                    var dto = _mapper.Map<TeacherDto>(record);
                    return new Response<TeacherDto>(dto);
                }
            }
        }
    }
}
