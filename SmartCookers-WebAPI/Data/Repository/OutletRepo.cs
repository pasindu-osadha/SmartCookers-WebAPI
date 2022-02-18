using AutoMapper;
using SmartCookers_WebAPI.Data.Interfaces;
using SmartCookers_WebAPI.Dtos.Outlet;
using SmartCookers_WebAPI.Models;

namespace SmartCookers_WebAPI.Data.Repository
{
    public class OutletRepo : IOutletRepo
    {
        private readonly SmartDbContext _context;
        private readonly IMapper _mapper;

        public OutletRepo(SmartDbContext context, IMapper mapper)
        {
            _context=context;
            _mapper=mapper;
        }
        public bool CreateOutlet(OutletCreateDto outletCreateDto)
        {
            var a = _mapper.Map<Outlet>(outletCreateDto);
            _context.Outlets.Add(a);
            return (_context.SaveChanges() >= 0);
        }
    }
}
