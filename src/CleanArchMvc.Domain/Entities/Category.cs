using System.Collections.Generic;
using CleanArchMvc.Domain.Exceptions;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category : Entity
    {
        public string Name { get; private set; }

        public ICollection<Product> Products { get; set; }

        public Category(string name)
        {
            ValidateDomain(name);

            Name = name;
        }

        public Category(int id, string name) : base(id)
        {
            ValidateDomain(name);

            Name = name;
        }

        public void Update(string name)
        {
            ValidateDomain(name);

            Name = name;
        }


        private void ValidateDomain(string name)
        {
            DomainValidationException.When(
                string.IsNullOrWhiteSpace(name), 
                "Invalid name. Name is required."
            );

            DomainValidationException.When(
                name.Length < 3, 
                "Invalid name. Name must be a minimum of 3 characters."
            );
        }
    }
}