using System.ComponentModel.DataAnnotations;

namespace InMemory.Model
{
    public class BlogPost
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
