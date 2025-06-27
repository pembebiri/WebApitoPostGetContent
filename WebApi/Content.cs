using System.ComponentModel.DataAnnotations;

namespace WebApi
{
    public class Content
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

    }
}
