namespace ToDoApi.Models
{
    public class ProblemDetailsObject<T>
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public decimal Status { get; set; }
        public string Detail { get; set; }
        public string Instance { get; set; }
        public T Extension { get; set; }
    }
}