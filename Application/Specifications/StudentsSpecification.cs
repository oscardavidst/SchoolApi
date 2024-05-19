using Ardalis.Specification;
using Domain.Entities;

namespace Application.Specifications
{
    public class StudentsSpecification : Specification<Student>
    {
        public StudentsSpecification(string name)
        {
            if (!string.IsNullOrEmpty(name))
                Query.Search(s => s.Name, "%" + name + "%");
        }
    }
}
