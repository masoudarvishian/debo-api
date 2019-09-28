using System;

namespace DEBO.Core.Entity
{
    /// <summary>
    /// Base entity for all entities across the project
    /// </summary>
    /// <typeparam name="T">Type of Id</typeparam>
    public class BaseEntity<T>
    {
        public T Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public bool IsDelete { get; set; }
    }
}
