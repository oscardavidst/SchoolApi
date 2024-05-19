using Ardalis.Specification;
using Domain.Entities;

namespace Application.Specifications
{
    public class TeachersSpecification : Specification<Teacher>
    {
        public TeachersSpecification(string name)
        {
            if (!string.IsNullOrEmpty(name))
                Query.Search(t => t.Name, "%" + name + "%");
        }
    }
}
