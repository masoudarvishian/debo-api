namespace DEBO.Core.ApplicationService.Item
{
    using Entity.Item;
    using DEBO.Core.ApplicationService.BaseService;
    using DEBO.Core.Entity.Item.Dtos;

    public interface IItemService : IBaseService<Item, int, ItemInputDto, ItemOutputDto, ItemUpdateDto>
    {
    }
}
