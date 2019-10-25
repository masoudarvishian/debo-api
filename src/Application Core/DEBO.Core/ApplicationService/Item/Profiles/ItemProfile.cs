namespace DEBO.Core.ApplicationService.Item.Profiles
{
    using AutoMapper;
    using Entity.Item;
    using Entity.Item.Dtos;

    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<Item, ItemOutputDto>();
            CreateMap<ItemInputDto, Item>();
            CreateMap<ItemUpdateDto, Item>();
        }
    }
}
