namespace DEBO.Core.Entity.Item.Dtos
{
    public class ItemOutputDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsExist { get; set; }

        public int CategoryId { get; set; }

        public int BusinessId { get; set; }
    }
}
