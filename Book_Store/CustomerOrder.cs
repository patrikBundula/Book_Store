using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace Book_Store
{
    public class CustomerOrder
    {
        public int Id { get; set; }
        public DateTime? OrderDate { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        [JsonIgnore]
        public virtual Customer Customer { get; set; }

        public int ShippingMethodId { get; set; }
        [ForeignKey("ShippingMethodId")]
        [JsonIgnore]
        public virtual ShippingMethod ShippingMethod { get; set; }

        public int AddressId { get; set; }
        [ForeignKey("AddressId")]
        [JsonIgnore]
        public virtual Address Address { get; set; }


    }
}
