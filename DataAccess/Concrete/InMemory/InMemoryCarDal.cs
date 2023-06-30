using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal //: ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car { Id = 1,BrandId = 1,ColorId=2,DailyPrice=34,Description="Mercedes",ModelYear=1993 },
                new Car { Id = 2,BrandId = 2,ColorId=3,DailyPrice=56,Description="Bmw",ModelYear=2001 },
                new Car { Id = 3,BrandId = 3,ColorId=1,DailyPrice=98,Description="Toyota",ModelYear=2005 },
                new Car { Id = 4,BrandId = 4,ColorId=4,DailyPrice=24,Description="Doblo",ModelYear=1989 },
                new Car { Id = 5,BrandId = 5,ColorId=5,DailyPrice=398,Description="Hundai",ModelYear=2020 },
                new Car { Id = 6,BrandId = 6,ColorId=2,DailyPrice=12,Description="Tesla",ModelYear=2009 },
            };
        }
        public void Add(Car entity)
        {
            _cars.Add(entity);
        }

        public void Delete(Car entity)
        {
            _cars.Remove(entity);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(p => p.Id == Id).ToList();
        }

        public void Update(Car entity)
        {
            Car carUpdate = _cars.SingleOrDefault(p => p.Id == entity.Id);
            carUpdate.Id = entity.Id;
            carUpdate.BrandId = entity.BrandId;
            carUpdate.ColorId = entity.ColorId;
            carUpdate.DailyPrice = entity.DailyPrice;
            carUpdate.Description = entity.Description;
            carUpdate.ModelYear = entity.ModelYear;
        }
    }
}
