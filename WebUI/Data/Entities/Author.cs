using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Data.Entities
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100),Required]
        public string FullName { get; set; }
        [Required]
        public Gender Gender { get; set; } // int
        public string Description { get; set; }
        public ICollection<Post> Posts { get; set; }
    }

    public enum Gender
    {
        Male = 1,
        Female = 2
    }
}
