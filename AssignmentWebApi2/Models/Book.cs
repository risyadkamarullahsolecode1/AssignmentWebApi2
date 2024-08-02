using System.ComponentModel.DataAnnotations;

namespace AssignmentWebApi2.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        [MinLength(1)]
        public string Title { get; set; }
        [Required]
        [MinLength(1)]
        public string Author { get; set; }
        [Required]
        public int PublicationYear { get; set; }
        [Required]  
        public string ISBN { get; set; }
    }
}
