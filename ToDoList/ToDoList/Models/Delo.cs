using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class Delo
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Название")]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Дата создания")]
        public DateTime CreatedDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Срок выполнения")]
        public DateTime DueDate { get; set; }
        
        [Display(Name = "Выполнение")]
        public bool IsCompleted { get; set; }
    }
}