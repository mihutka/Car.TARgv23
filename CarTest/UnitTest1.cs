using Car.TARgv23.ApplicationServices.Services;
using Car.TARgv23.Core.Dto;
using Car.TARgv23.Core.ServerInterface;

namespace CarTest
{
    public class UnitTest1 : TestBase
    {
        [Fact]
        public async Task Should_Create_Car()
        {
            var dto = new CarDto
            {
                Brand = "TestBrand",
                Model = "TestModel",
                Number = "123ABC",
                Mileage = 5000,
            };

            var createdCar = await Svc<ICarInterface>().Create(dto);

            Assert.NotNull(createdCar);
            Assert.Equal(dto.Brand, createdCar.Brand);
            Assert.Equal(dto.Model, createdCar.Model);
            Assert.Equal(dto.Number, createdCar.Number);
            Assert.Equal(dto.Mileage, createdCar.Mileage);
        }

        [Fact]
        public async Task Should_Update_CarMileage()
        {
            var dto = new CarDto
            {
                Brand = "TestBrand",
                Model = "TestModel",
                Number = "123ABC",
                Mileage = 5000,
            };

            var createdCar = await Svc<ICarInterface>().Create(dto);

            var updatedDto = new CarDto
            {
                Id = createdCar.Id,
                Brand = "TestBrand",
                Model = "TestModel",
                Number = "123ABC",
                Mileage = 7000,
            };

            var updatedCar = await Svc<ICarInterface>().Update(updatedDto);

            Assert.NotNull(updatedCar);
            Assert.NotEqual(dto.Mileage, updatedCar.Mileage);
            Assert.Equal(updatedDto.Mileage, updatedCar.Mileage);
        }

        [Fact]
        public async Task Should_ReturnNull_WhenCarNotFound()
        {
            Guid nonExistingId = Guid.NewGuid();
            var result = await Svc<ICarInterface>().DetailsAsync(nonExistingId);
            Assert.Null(result);
        }

        [Fact]
        public async Task Should_Update_CarNumber()
        {
            var dto = new CarDto
            {
                Brand = "TestBrand",
                Model = "TestModel",
                Number = "123ABC",
                Mileage = 5000,
            };

            var createdCar = await Svc<ICarInterface>().Create(dto);

            var updatedDto = new CarDto
            {
                Id = createdCar.Id,
                Brand = "TestBrand",
                Model = "TestModel",
                Number = "456DEF",
                Mileage = 5000,
            };

            var updatedCar = await Svc<ICarInterface>().Update(updatedDto);

            Assert.NotNull(updatedCar);
            Assert.Equal(updatedDto.Number, updatedCar.Number);
            Assert.NotEqual(dto.Number, updatedCar.Number);
        }
    }
}