﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
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
    }
}
