using AutoMapper;
using DEBO.Core.DomainService;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DEBO.Infrastructure.Libraries.AutoMapperLib
{
    public class DataMapper : IDataMapper
    {
        private readonly IMapper _mapper;

        public DataMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public TDestination Map<TDestination>(object source)
        {
            return _mapper.Map<TDestination>(source);
        }

        public IQueryable<TDestination> ProjectTo<TDestination>(IQueryable source, object parameters = null, params Expression<Func<TDestination, object>>[] membersToExpand)
        {
            return _mapper.ProjectTo<TDestination>(source);
        }
    }
}
