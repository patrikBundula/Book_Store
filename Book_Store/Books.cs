using System.ComponentModel.DataAnnotations;

namespace Book_Store
{
    public class Books
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }

        public float Price { get; set; }
        public virtual Author Author { get; set; }

        public virtual Category Category { get; set; }

    }
}
