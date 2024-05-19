using Ardalis.Specification;
using Domain.Entities;

namespace Application.Specifications
{
    public class ScoresSpecification : Specification<Score>
    {
        public ScoresSpecification(string name, decimal? value, int? idStudent, int? idTeacher)
        {
            if (!string.IsNullOrEmpty(name))
                Query.Search(s => s.Name, "%" + name + "%");

            if (value != null)
                Query.Where(s => s.Value == value);

            if (idStudent != null)
                Query.Where(s => s.IdStudent == idStudent);

            if (idTeacher != null)
                Query.Where(s => s.IdTeacher == idTeacher);
        }
    }
}
