using CleanArchMvc.Domain.Exceptions;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public Product(
            string name, 
            string description,
            decimal price,
            int stock,
            string image)
        {
            ValidateDomain(name, description, price, stock, image);

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }

        public Product(
            int id,
            string name, 
            string description,
            decimal price,
            int stock,
            string image) : base(id)
        {
            ValidateDomain(name, description, price, stock, image);

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }

        public void Update(
            string name, 
            string description,
            decimal price,
            int stock,
            string image,
            int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;

            CategoryId = categoryId;
        }


        private void ValidateDomain(
            string name, 
            string description,
            decimal price,
            int stock,
            string image)
        {
            DomainValidationException.When(
                string.IsNullOrWhiteSpace(name), 
                "Invalid name. Name is required."
            );

            DomainValidationException.When(
                name.Length < 3, 
                "Invalid name. Name must be a minimum of 3 characters."
            );

            DomainValidationException.When(
                string.IsNullOrWhiteSpace(description), 
                "Invalid description. Description is required."
            );

            DomainValidationException.When(
                description.Length < 5, 
                "Invalid description. Description must be a minimum of 5 characters."
            );

            DomainValidationException.When(
                image.Length > 250,
                "Invalid image. Image must be a maximum of 250 characters"
            );
        }
    }
}