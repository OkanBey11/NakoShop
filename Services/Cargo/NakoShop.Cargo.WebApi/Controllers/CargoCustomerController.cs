using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NakoShop.Cargo.BusinessLayer.Concrete;
using NakoShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using NakoShop.Cargo.EntityLayer.Concrete;

namespace NakoShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomerController : ControllerBase
    {
        private readonly CargoCustomerManager _cargoCustomerManager;

        public CargoCustomerController(CargoCustomerManager cargoCustomerManager)
        {
            _cargoCustomerManager = cargoCustomerManager;
        }

        [HttpGet]
        public IActionResult CargoCustomerList()
        {
            var values = _cargoCustomerManager.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetByIdCargoCustomer(int id)
        {
            var value = _cargoCustomerManager.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
                Name = createCargoCustomerDto.Name,
                Surname = createCargoCustomerDto.Surname,
                Email = createCargoCustomerDto.Email,
                Phone = createCargoCustomerDto.Phone,
                District = createCargoCustomerDto.District,
                City = createCargoCustomerDto.City,
                Address = createCargoCustomerDto.Address,
            };

            _cargoCustomerManager.TInsert(cargoCustomer);
            return Ok("Cargo Customer Created");
        }

        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
                CargoCustomerId = updateCargoCustomerDto.CargoCustomerId,
                Name = updateCargoCustomerDto.Name,
                Surname = updateCargoCustomerDto.Surname,
                Email = updateCargoCustomerDto.Email,
                Phone = updateCargoCustomerDto.Phone,
                District = updateCargoCustomerDto.District,
                City = updateCargoCustomerDto.City,
                Address = updateCargoCustomerDto.Address,
            };

            _cargoCustomerManager.TUpdate(cargoCustomer);
            return Ok("Cargo Customer Updated");
        }

        [HttpDelete]
        public IActionResult DeleteCargoCustomer(int id)
        {
            _cargoCustomerManager.TDelete(id);
            return Ok("Cargo Customer Deleted");
        }
    }
}
