using Database.Entity;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Money { get; set; }
    }
}
