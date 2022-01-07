
namespace Core.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
        public long Price { get; set; }
        public string Currency { get; set; }
    }
}