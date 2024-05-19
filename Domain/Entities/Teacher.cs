using Domain.Common;

namespace Domain.Entities
{
    public class Teacher : AuditableBaseEntity
    {
        public string Name { get; set; }

        // Navigations
        public ICollection<Score> Scores { get; set; }
    }
}
