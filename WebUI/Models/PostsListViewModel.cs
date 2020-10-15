using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Data.Entities;

namespace WebUI.Models
{
    public class PostsListViewModel
    {
        public int Id { get; set; }
        public string Author { get; set; } 
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; }
        public string Content { get; set; }
    }
}
