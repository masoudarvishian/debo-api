using System;

namespace DEBO.Core.Entity
{
    /// <summary>
    /// Base entity for all entities across the project
    /// </summary>
    /// <typeparam name="TKey">Type of Id</typeparam>
    public class BaseEntity<TKey> : IEntity
    {
        public BaseEntity()
        {
            CreateDate = DateTime.Now;
            ModifyDate = DateTime.Now;
            IsDelete = false;
        }

        public TKey Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public bool IsDelete { get; set; }
    }
}
