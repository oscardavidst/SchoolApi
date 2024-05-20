using Domain.Common;

namespace Domain.Entities
{
    public class Log
    {
        public virtual int Id { get; set; }
        public DateTime Date { get; set; }
        public string Level { get; set; }
        public string Message { get; set; }
        public string Logger { get; set; }
    }
}
