using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Data.Entities;

namespace WebUI.Models
{
    public class PostRequestViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Select Author")]
        public int AuthorId { get; set; } 
        [Required(ErrorMessage ="Please Select Status")]
        public Status Status { get; set; }
        [Required, MaxLength(250)]
        public string Content { get; set; }
    }
}
