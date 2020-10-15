using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Data.Entities
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int AuthorId { get; set; } // foreign keys
        public DateTime CreatedAt { get; set; }
        [Required]
        public Status Status { get; set; }
        [Required, MaxLength(250)]
        public string  Content { get; set; }
        public  Author Author { get; set; }
    }

    public enum Status
    {
        Enabled =1,
        Disabled = 2
    }
}
