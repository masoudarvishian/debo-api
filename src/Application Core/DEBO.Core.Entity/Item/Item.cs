namespace DEBO.Core.Entity.Item
{
    using Category;
    using Business;

    public class Item : BaseEntity<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsExist { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int BusinessId { get; set; }
        public Business Business { get; set; }
    }
}
