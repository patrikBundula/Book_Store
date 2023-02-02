using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Book_Store
{
    public class OrderLine
    {
        public int Id { get; set; }
        public int MyProperty { get; set; }

        public int CustomOrderId { get; set; }
        [ForeignKey("CustomOrderId")]
        [JsonIgnore]
        public virtual CustomerOrder CustomerOrder { get; set; }

        public int BookId { get; set; }
        [ForeignKey("BookId")]
        [JsonIgnore]
        public virtual Books Books { get; set; }

        public float Price { get; set; }

    }
}
