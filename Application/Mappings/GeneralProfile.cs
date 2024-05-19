using Application.DTOs;
using Application.Features.Students.Commands.CreateStudentCommand;
using Application.Features.Teachers.Commands.CreateTeacherCommand;
using Application.Features.Scores.Commands.CreateScoreCommand;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region DTOs
            CreateMap<Student, StudentDto>();
            CreateMap<Teacher, TeacherDto>();
            CreateMap<Score, ScoreDto>();
            #endregion

            #region Commands
            CreateMap<CreateStudentCommand, Student>();
            CreateMap<CreateTeacherCommand, Teacher>();
            CreateMap<CreateScoreCommand, Score>();
            #endregion
        }
    }
}
