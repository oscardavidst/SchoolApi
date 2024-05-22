namespace Application.DTOs
{
    public class ScoreDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public int IdStudent { get; set; }
        public int IdTeacher { get; set; }
        public string StudentName { get; set; }
        public string TeacherName { get; set; }
    }
}
