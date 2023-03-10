using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Database.Entity
{
    public class Books
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }

        [Required]
        public float Price { get; set; }
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        [JsonIgnore]
        public virtual Author Author { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [JsonIgnore]
        public virtual Category Category { get; set; }
        public bool IsDeleted { get; set; }

    }
}
