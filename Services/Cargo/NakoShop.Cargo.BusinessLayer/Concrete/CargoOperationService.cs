using NakoShop.Cargo.BusinessLayer.Abstract;
using NakoShop.Cargo.DataAccessLayer.Abstract;
using NakoShop.Cargo.EntityLayer.Concrete;

namespace NakoShop.Cargo.BusinessLayer.Concrete
{
    public class CargoOperationService : ICargoOperationsService
    {
        private readonly ICargoOperationDal _cargoOperationDal;

        public CargoOperationService(ICargoOperationDal cargoOperationDal)
        {
            _cargoOperationDal = cargoOperationDal;
        }

        public void TDelete(int id)
        {
            _cargoOperationDal.Delete(id);
        }

        public List<CargoOperation> TGetAll()
        {
            return _cargoOperationDal.GetAll();
        }

        public CargoOperation TGetById(int id)
        {
            return _cargoOperationDal.GetById(id);
        }

        public void TInsert(CargoOperation entity)
        {
            _cargoOperationDal.Insert(entity);
        }

        public void TUpdate(CargoOperation entity)
        {
            _cargoOperationDal.Update(entity);
        }
    }
}
