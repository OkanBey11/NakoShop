using NakoShop.Cargo.DataAccessLayer.Abstract;
using NakoShop.Cargo.DataAccessLayer.Concrete;
using NakoShop.Cargo.DataAccessLayer.Repositories;
using NakoShop.Cargo.EntityLayer.Concrete;

namespace NakoShop.Cargo.DataAccessLayer.EntityFramework
{
    public class EfCargoCustomerDal : GenericRepository<CargoCustomer>, ICargoCustomerDal
    {
        public EfCargoCustomerDal(CargoContext context) : base(context)
        {

        }
    }
}
