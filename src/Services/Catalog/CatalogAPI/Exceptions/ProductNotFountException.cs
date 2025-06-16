using BuildingBlocks.Exceptions;

namespace CatalogAPI.Exceptions
{
    public class ProductNotFountException : NotFoundException
    {
        public ProductNotFountException(Guid Id) : base("Product", Id) 
        {

        }
    }
}
