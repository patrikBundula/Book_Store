using System.ComponentModel.DataAnnotations;

namespace Book_Store.Dtos
{
    public class EditBookDto
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter the title of the book")]
        [MaxLength(255)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Range(0, 250, ErrorMessage = "Please enter a correct value")]
        public float Price { get; set; }
        [Required]

        public int AuthorId { get; set; }
        [Required]

        public int CategoryId { get; set; }
    }
}
