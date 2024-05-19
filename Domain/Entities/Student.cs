using Domain.Common;

namespace Domain.Entities
{
    public class Student : AuditableBaseEntity
    {
        public string Name { get; set; }

        // Navigations
        public ICollection<Score> Scores { get; set; }
    }
}
