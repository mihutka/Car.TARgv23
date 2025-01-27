using Car.TARgv23.Core.Domain;
using Car.TARgv23.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.TARgv23.Core.ServerInterface
{
    public interface ICarInterface
    {
        Task<CarDomain> DetailsAsync(Guid id);
        Task<CarDomain> Update(CarDto dto);
        Task<CarDomain> Delete(Guid id);
        Task<CarDomain> Create(CarDto dto);
    }
}
