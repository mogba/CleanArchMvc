using CleanArchMvc.Domain.Exceptions;

namespace CleanArchMvc.Domain.Entities
{
    public abstract class Entity
    {
        public int Id { get; protected set; }

        protected Entity(int id)
        {
            DomainValidationException.When(
                id <= 0,
                "Invalid ID. ID is required."
            );

            Id = id;
        }

        protected Entity() {}
    }
}