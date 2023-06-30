using Core.DataAccess.Entityframework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectSQL>, ICarDal
    {
        public List<CarDetailsDto> GetAllDetails()
        {
            using (ReCapProjectSQL context=new ReCapProjectSQL())
            {
                var result = from car in context.Cars
                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId
                             join color in context.Colors
                             on car.ColorId equals color.ColorId
                             select new CarDetailsDto
                             {
                                 CarName=car.Description,
                                 BrandName=brand.BrandName,
                                 ColorName=color.ColorName,
                                 DailyPrice=car.DailyPrice,
                             };
                return result.ToList();
            }
        }
    }
}
