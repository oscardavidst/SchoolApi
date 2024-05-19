namespace Application.Features.Scores.Queries.GetAllScores
{
    public class GetAllScoresParameters
    {
        public string? Name { get; set; }
        public decimal? Value { get; set; }
        public int? IdStudent { get; set; }
        public int? IdTeacher { get; set; }
    }
}
