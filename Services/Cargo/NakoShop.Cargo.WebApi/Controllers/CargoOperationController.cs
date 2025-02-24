using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NakoShop.Cargo.BusinessLayer.Concrete;
using NakoShop.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using NakoShop.Cargo.EntityLayer.Concrete;

namespace NakoShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationController : ControllerBase
    {
        private readonly CargoOperationManager _cargoOperationManager;

        public CargoOperationController(CargoOperationManager cargoOperationManager)
        {
            _cargoOperationManager = cargoOperationManager;
        }

        [HttpGet]
        public IActionResult CargoOperationList()
        {
            var values = _cargoOperationManager.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetByIdCargoOperation(int id)
        {
            var value = _cargoOperationManager.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateCargoOperation(CreateCargoOperationDto createCargoOperationDto)
        {
            CargoOperation cargoOperation = new CargoOperation()
            {
                Barcode = createCargoOperationDto.Barcode,
                Description = createCargoOperationDto.Description,
                OperationDate = createCargoOperationDto.OperationDate,
            };

            _cargoOperationManager.TInsert(cargoOperation);
            return Ok("Cargo Operation Created");
        }

        [HttpPut]
        public IActionResult UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
        {
            CargoOperation cargoOperation = new CargoOperation()
            {
                Barcode = updateCargoOperationDto.Barcode,
                Description = updateCargoOperationDto.Description,
                CargoOperationId = updateCargoOperationDto.CargoOperationId,
                OperationDate = updateCargoOperationDto.OperationDate,
            };

            _cargoOperationManager.TUpdate(cargoOperation);
            return Ok("Cargo Operation Updated");
        }

        [HttpDelete]
        public IActionResult DeleteCargoOperation(int id)
        {
            _cargoOperationManager.TDelete(id);
            return Ok("Cargo Deleted");
        }
    }
}
