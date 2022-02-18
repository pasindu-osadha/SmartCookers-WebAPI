using SmartCookers_WebAPI.Dtos.Product;
using SmartCookers_WebAPI.Dtos.ProductInOutlet;

namespace SmartCookers_WebAPI.Data.Interfaces
{
    public interface IProductRepo
    {
        Task<IEnumerable<ProductReadDto>> GetAllProducts();
        ProductReadDto GetProductById(Guid id);
        ProductReadDto GetProductByName(string name);
        ProductReadDto AddProduct(ProductCreateDto productCreateDto);
        IEnumerable<ProductInOutletReadDto> GetProductinOutlet(string outlet);
        ProductInOutletReadDto GetProductinOutletItem(Guid id);
    }
}
