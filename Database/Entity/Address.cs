namespace Database.Entity
{
    public class Address
    {
        public int Id { get; set; }

        public int StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string CityName { get; set; }
        public string CountryName { get; set; }
    }
}
