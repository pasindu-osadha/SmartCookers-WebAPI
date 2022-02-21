using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartCookers_WebAPI.Constants;
using SmartCookers_WebAPI.Data.Interfaces;
using SmartCookers_WebAPI.Dtos.Order;
using SmartCookers_WebAPI.Models;

namespace SmartCookers_WebAPI.Data.Repository
{
    public class OrderRepo : IOrderRepo
    {
        private readonly SmartDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<SmartUser> _userManager;

        public OrderRepo(SmartDbContext context, IMapper mapper, UserManager<SmartUser> userManager)
        {
            _context = context;
            _mapper=mapper;
            _userManager=userManager;
        }
        public async Task<bool> CreateOrder(OrderCreateDto orderCreateDto, SmartUser user)
        {

            var productinoutlet = _context.Product_In_Outlets.FirstOrDefault(p => p.Id == orderCreateDto.productInOutletId);  //            FindByIdAsync(orderCreateDto.productInOutletId);
            if (productinoutlet == null)
                return false;

            productinoutlet.Available_qty = productinoutlet.Available_qty - orderCreateDto.product_Order_Qty;
            productinoutlet.LastUpdatedDate = DateTime.Now;
            _context.Product_In_Outlets.Update(productinoutlet);

            var products = _context.Products.FirstOrDefault(p=>p.Id == orderCreateDto.productId);
            if (products == null)
                return false;
            products.Product_Quantity = products.Product_Quantity- orderCreateDto.product_Order_Qty;
            _context.Products.Update(products);

            Order ordermodel = new Order { 
                
                Order_Date = DateTime.Now,
                Order_Status="In progress",
                TotalAmount = orderCreateDto.totalAmount,
                SmartUser= user,
                LastUpdatedDate = DateTime.Now,

            };

            _context.Order.Add(ordermodel);

            Product_Order product_Order = new Product_Order { 
                Order = ordermodel,
                Product_In_Outlet=productinoutlet,
                Product_Order_Qty=orderCreateDto.product_Order_Qty,
                Product_Order_Amount=orderCreateDto.totalAmount
                
            };

            _context.Product_Order.Add(product_Order);

           var result =  (_context.SaveChanges()>0);

            return result;
        }

        public async Task<IEnumerable<TransactionHistoryDto>> viewTransactionHistoryAsync(SmartUser user, string userrole)
        {

            if (userrole == UserRoles.Customer)
            {

                var orderdata = await _context.Order.Where(o => o.SmartUser == user).Include(o => o.Product_Orders).ThenInclude(po => po.Product_In_Outlet).ThenInclude(pi => pi.Product)
                    .Include(o => o.Product_Orders).ThenInclude(po => po.Product_In_Outlet).ThenInclude(pi => pi.Outlet).ToListAsync();
                return _mapper.Map<IEnumerable<TransactionHistoryDto>>(orderdata);
            }

            else
            {
                var data = await _context.Order.Include(o => o.Product_Orders).ThenInclude(po => po.Product_In_Outlet).ThenInclude(pi => pi.Product)
                    .Include(o => o.Product_Orders).ThenInclude(po => po.Product_In_Outlet).ThenInclude(pi => pi.Outlet).ToListAsync();
                
                return _mapper.Map<IEnumerable<TransactionHistoryDto>>(data);
            }
        }
    }
}
