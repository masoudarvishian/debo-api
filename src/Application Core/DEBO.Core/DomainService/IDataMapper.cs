using System;
using System.Linq;
using System.Linq.Expressions;

namespace DEBO.Core.DomainService
{
    public interface IDataMapper
    {
        TDestination Map<TDestination>(object source);

        IQueryable<TDestination> ProjectTo<TDestination>(IQueryable source,
            object parameters = null,
            params Expression<Func<TDestination, object>>[] membersToExpand);
    }
}