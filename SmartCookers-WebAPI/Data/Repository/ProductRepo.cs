using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmartCookers_WebAPI.Data.Interfaces;
using SmartCookers_WebAPI.Dtos.Product;
using SmartCookers_WebAPI.Dtos.ProductInOutlet;
using SmartCookers_WebAPI.Models;

namespace SmartCookers_WebAPI.Data.Repository
{
    public class ProductRepo : IProductRepo
    {
        private readonly SmartDbContext _context;
        private readonly IMapper _mapper;

        public ProductRepo(SmartDbContext context, IMapper mapper)
        {
            _context=context;
            _mapper=mapper;
        }

       
        public async Task<IEnumerable<ProductReadDto>> GetAllProducts()
        {
          var result = _context.Products.Include(P => P.Product_Picture).ToList();
            return _mapper.Map<IEnumerable<ProductReadDto>>(result);

        }

        public ProductReadDto GetProductById(Guid id)
        {
            var result = _context.Products.Include(p => p.Product_Picture).FirstOrDefault(p=>p.Id==id);
            return _mapper.Map<ProductReadDto>(result);
            //throw new NotImplementedException();
        }

        public ProductReadDto GetProductByName(string name)
        {
            throw new NotImplementedException();
        }

        public ProductReadDto AddProduct(ProductCreateDto productCreateDto)
        {
            var p  = _mapper.Map<Product>(productCreateDto);

            //var p = new Product
            //{
            //    Product_Name=productCreateDto.Product_Name,
            //    Product_Description=productCreateDto.Product_Description,
            //    Product_Quantity=productCreateDto.Product_Quantity,
            //    Product_UnitPrice=productCreateDto.Product_UnitPrice,
            //    Product_Picture = new List<Product_Picture> { new Product_Picture { Product_Picture_Url=productCreateDto.Product_Picture_Url} }
            //};
            
            _context.Products.Add(p);
            _context.SaveChanges();
            return _mapper.Map<ProductReadDto>(p);
        }

        public IEnumerable<ProductInOutletReadDto> GetProductinOutlet(string outletName)
        {

            var outletResult =  _context.Outlets.Where(p => p.Outlet_Name == outletName).FirstOrDefault();
            if (outletResult == null)
                return null;

            var result = _context.Product_In_Outlets.Where(p => p.Outlet.Id == outletResult.Id).Include(p=>p.Product).ThenInclude(p=>p.Product_Picture).ToList();

            return _mapper.Map<IEnumerable<ProductInOutletReadDto>>(result);

           
        }

        public ProductInOutletReadDto GetProductinOutletItem(Guid id)
        {
            var result = _context.Product_In_Outlets.Where(p => p.Id == id).Include(p => p.Product).ThenInclude(p => p.Product_Picture).FirstOrDefault();

            return _mapper.Map<ProductInOutletReadDto>(result);
        }
    }
}
