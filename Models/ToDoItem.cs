using System.ComponentModel.DataAnnotations;

namespace ToDoApi.Models
{
    public class ToDoItem
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "タイトルは必須入力です。")]
        public string Title { get; set; }

        public string Notes { get; set; }

        public bool? IsCompleted { get; set; }
    }
}