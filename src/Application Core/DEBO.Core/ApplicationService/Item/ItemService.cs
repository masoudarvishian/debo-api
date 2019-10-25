namespace DEBO.Core.ApplicationService.Item
{
    using AutoMapper;
    using DEBO.Core.DomainService;
    using Entity.Item;
    using DEBO.Core.Entity.Item.Dtos;
    public class ItemService 
        : BaseService.BaseService<Item, int, ItemInputDto, ItemOutputDto, ItemUpdateDto>, 
        IItemService
    {
        public ItemService(IUnitOfWork<Item> unitOfWork, IMapper dataMapper) 
            : base(unitOfWork, dataMapper)
        {
        }
    }
}
