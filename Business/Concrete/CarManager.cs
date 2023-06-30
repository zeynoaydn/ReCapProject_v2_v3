using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager:ICarService
    {
        ICarDal _car;
        public CarManager(ICarDal carDal)
        {
            _car = carDal;
        }

        public void Add(Car car)
        {
            if(car.Description.Length>=2 && car.DailyPrice>0)
            {
                _car.Add(car);
            }
            else
            {
                Console.WriteLine("Bilgiler yanlış");
            }
        }

        public void Delete(Car car)
        {
            _car.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _car.GetAll();
        }

        public List<CarDetailsDto> GetAllDetails()
        {
            return _car.GetAllDetails();
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _car.GetAll(p=>p.BrandId== brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _car.GetAll(p=>p.ColorId== colorId);
        }

        public void Update(Car car)
        {
            _car.Update(car);
        }
    }
}
