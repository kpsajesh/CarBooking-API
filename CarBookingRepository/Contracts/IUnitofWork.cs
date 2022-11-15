using CarBookingData.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookingRepository.Contracts
{
    public interface IUnitofWork: IDisposable // going to be a register for generic repository relative to the class TEntity
    {
        IGenericRepository<Style> Styles { get; }
        IGenericRepository<Make> Makes{ get; }
        IGenericRepository<CarModel> CarModels { get; }
        IGenericRepository<Car> Cars { get; }
        Task Save();
        
    }
}
