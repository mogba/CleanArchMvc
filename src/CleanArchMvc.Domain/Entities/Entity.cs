using CleanArchMvc.Domain.Exceptions;

namespace CleanArchMvc.Domain.Entities
{
    public abstract class Entity
    {
        public int Id { get; protected set; }

        protected Entity() {}
    }
}