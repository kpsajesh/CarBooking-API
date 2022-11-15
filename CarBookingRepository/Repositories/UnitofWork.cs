using CarBookingData.DataModels;
using CarBookingRepository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookingRepository.Repositories
{
    public class UnitofWork:IUnitofWork
    {
        private readonly CarBookingDbContext _context;
        private IGenericRepository<Style> _styles;
        private IGenericRepository<Make> _makes;
        private IGenericRepository<CarModel> _carmodels;
        private IGenericRepository<Car> _cars;


        public UnitofWork(CarBookingDbContext context)
        {
            this._context = context;
        }
        public IGenericRepository<Style> Styles => _styles??= new GenericRepository<Style>(_context); // Here ?? means if styles not equal to null then
        public IGenericRepository<Make> Makes => _makes ??= new GenericRepository<Make>(_context);
        public IGenericRepository<CarModel> CarModels => _carmodels ??= new GenericRepository<CarModel>(_context);
        public IGenericRepository<Car> Cars => _cars ??= new GenericRepository<Car>(_context);
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

    }
}
