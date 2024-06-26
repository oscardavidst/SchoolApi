﻿using Application.DTOs;
using Application.Interfaces;
using Application.Specifications;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Scores.Queries.GetAllScores
{
    public class GetAllScoresQuery : IRequest<Response<List<ScoreDto>>>
    {
        public string? Name { get; set; }
        public decimal? Value { get; set; }
        public int? IdStudent { get; set; }
        public int? IdTeacher { get; set; }

        public class GetAllScoresQueryHandler : IRequestHandler<GetAllScoresQuery, Response<List<ScoreDto>>>
        {
            private readonly IRepositoryAsync<Score> _repositoryAsync;
            private readonly IRepositoryAsync<Teacher> _repositoryTeachersAsync;
            private readonly IRepositoryAsync<Student> _repositoryStudentsAsync;
            private readonly IMapper _mapper;

            public GetAllScoresQueryHandler(IRepositoryAsync<Score> repositoryAsync, IMapper mapper, IRepositoryAsync<Teacher> repositoryTeachersAsync, IRepositoryAsync<Student> repositoryStudentsAsync)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
                _repositoryTeachersAsync = repositoryTeachersAsync;
                _repositoryStudentsAsync = repositoryStudentsAsync;
            }

            public async Task<Response<List<ScoreDto>>> Handle(GetAllScoresQuery request, CancellationToken cancellationToken)
            {
                var records = await _repositoryAsync.ListAsync(new ScoresSpecification(request.Name, request.Value, request.IdStudent, request.IdTeacher));
                var recordsDto = _mapper.Map<List<ScoreDto>>(records);
                foreach(var record in recordsDto)
                {
                    var student = await _repositoryStudentsAsync.GetByIdAsync(record.IdStudent, cancellationToken);
                    var teacher = await _repositoryTeachersAsync.GetByIdAsync(record.IdTeacher, cancellationToken);
                    record.StudentName = student.Name;
                    record.TeacherName = teacher.Name;
                }
                return new Response<List<ScoreDto>>(recordsDto);
            }
        }
    }
}
