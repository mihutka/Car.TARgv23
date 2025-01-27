using Car.TARgv23.Core.Domain;
using Car.TARgv23.Data;
using Car.TARgv23.Core.Dto;
using Car.TARgv23.Core.ServerInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Car.TARgv23.ApplicationServices.Services
{
    public class CarServices : ICarInterface
    {
        private readonly CarContext _context;

        public CarServices(CarContext context)
        {
            _context = context;
        }

        public async Task<CarDomain> DetailsAsync(Guid id)
        {
            var result = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<CarDomain> Create(CarDto dto)
        {
            var car = new CarDomain
            {
                Id = Guid.NewGuid(),
                Brand = dto.Brand,
                Model = dto.Model,
                Number = dto.Number,
                Mileage = dto.Mileage,
                TechnicalInspection = dto.TechnicalInspection,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            };

            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();

            return car;
        }

        public async Task<CarDomain> Update(CarDto dto)
        {
            var car = await _context.Cars.FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (car == null)
            {
                return null;
            }

            car.Brand = dto.Brand;
            car.Model = dto.Model;
            car.Number = dto.Number;
            car.Mileage = dto.Mileage;
            car.TechnicalInspection = dto.TechnicalInspection;
            car.ModifiedAt = DateTime.Now;

            _context.Cars.Update(car);
            await _context.SaveChangesAsync();

            return car;
        }

        public async Task<CarDomain> Delete(Guid id)
        {
            var car = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == id);

            if (car == null)
            {
                return null;
            }

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();

            return car;
        }
    }
}
