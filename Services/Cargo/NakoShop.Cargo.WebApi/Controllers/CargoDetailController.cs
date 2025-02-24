using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NakoShop.Cargo.BusinessLayer.Concrete;
using NakoShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using NakoShop.Cargo.EntityLayer.Concrete;

namespace NakoShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailController : ControllerBase
    {
        private readonly CargoDetailManager _cargoDetailManager;

        public CargoDetailController(CargoDetailManager cargoDetailManager)
        {
            _cargoDetailManager = cargoDetailManager;
        }

        [HttpGet]
        public IActionResult CargoDetailList()
        {
            var values = _cargoDetailManager.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetByIdCargoDetail(int id)
        {
            var value = _cargoDetailManager.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
        {
            CargoDetail cargoDetail = new CargoDetail()
            {
                SenderCustomer = createCargoDetailDto.SenderCustomer,
                ReceiverCustomer = createCargoDetailDto.ReceiverCustomer,
                Barcode = createCargoDetailDto.Barcode,
                CargoCompanyId = createCargoDetailDto.CargoCompanyId
            };

            _cargoDetailManager.TInsert(cargoDetail);
            return Ok("Cargo Detail Created");
        }

        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDeatilDto updateCargoDeatilDto)
        {
            CargoDetail cargoDetail = new CargoDetail()
            {
                CargoDetailId = updateCargoDeatilDto.CargoDetailId,
                SenderCustomer = updateCargoDeatilDto.SenderCustomer,
                ReceiverCustomer = updateCargoDeatilDto.ReceiverCustomer,
                Barcode = updateCargoDeatilDto.Barcode,
                CargoCompanyId = updateCargoDeatilDto.CargoCompanyId
            };

            _cargoDetailManager.TUpdate(cargoDetail);
            return Ok("Cargo Deatil Updated");
        }

        [HttpDelete]
        public IActionResult DeleteCargoDetail(int id)
        {
            _cargoDetailManager.TDelete(id);
            return Ok("Cargo Detail Deleted");
        }

    }
}
