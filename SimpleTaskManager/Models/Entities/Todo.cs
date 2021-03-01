using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleTaskManager.Models.Entities
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 5)]
        public string Name { get; set; }

        public TodoType TodoType { get; set; }

        [Required]
        public int TodoTypeId { get; set; }

        [Required]
        public string StartDate { get; set; }

        [Required]
        public string StartAt { get; set; }

        [Required]
        public string FinishDate { get; set; }

        [Required]
        public string FinishAt { get; set; }
    }
}
