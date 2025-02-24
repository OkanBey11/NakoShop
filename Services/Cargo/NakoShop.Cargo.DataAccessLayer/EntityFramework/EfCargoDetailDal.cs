using NakoShop.Cargo.DataAccessLayer.Abstract;
using NakoShop.Cargo.DataAccessLayer.Concrete;
using NakoShop.Cargo.DataAccessLayer.Repositories;
using NakoShop.Cargo.EntityLayer.Concrete;

namespace NakoShop.Cargo.DataAccessLayer.EntityFramework
{
    public class EfCargoDetailDal : GenericRepository<CargoDetail>, ICargoDetailDal
    {
        public EfCargoDetailDal(CargoContext context) : base(context)
        {

        }
    }
}
