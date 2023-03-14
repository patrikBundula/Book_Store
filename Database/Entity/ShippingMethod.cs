namespace Database.Entity
{
    public class ShippingMethod
    {
        public int Id { get; set; }
        public string MethodName { get; set; }

        public float Cost { get; set; }

        public string Description { get; set; }
    }
}
