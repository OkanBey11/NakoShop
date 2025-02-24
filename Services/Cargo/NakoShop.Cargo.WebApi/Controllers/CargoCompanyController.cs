using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NakoShop.Cargo.BusinessLayer.Abstract;
using NakoShop.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using NakoShop.Cargo.EntityLayer.Concrete;

namespace NakoShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompanyController : ControllerBase
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoCompanyController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        [HttpGet]
        public IActionResult CargoCompanyList()
        {
            var values = _cargoCompanyService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
        {
            CargoCompany cargoCompany = new CargoCompany();
            cargoCompany.CargoCompanyName = createCargoCompanyDto.CargoCompanyName;
            _cargoCompanyService.TInsert(cargoCompany);
            return Ok("Cargo company created");
        }

        [HttpDelete]
        public IActionResult DeleteCargoCompany(int id)
        {
            _cargoCompanyService.TDelete(id);
            return Ok("Cargo Company Deleted");
        }

        [HttpGet("{id}")]
        public IActionResult GetByIdCargoCompany(int id)
        {
            var values = _cargoCompanyService.TGetById(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            CargoCompany cargoCompany=new CargoCompany();
            cargoCompany.CargoCompanyId = updateCargoCompanyDto.CargoCompanyId;
            cargoCompany.CargoCompanyName = updateCargoCompanyDto.CargoCompanyName;
            _cargoCompanyService.TUpdate(cargoCompany);
            return Ok("Cargo Company Update");
        }

    }
}
