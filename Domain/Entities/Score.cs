using Domain.Common;

namespace Domain.Entities
{
    public class Score : AuditableBaseEntity
    {
        public string Name { get; set; }
        public decimal Value { get; set; }

        // Foreigns Keys
        public int IdStudent { get; set; }
        public int IdTeacher { get; set; }
    }
}
