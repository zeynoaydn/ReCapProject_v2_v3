using Business.Concrete;
using DataAccess.Concrete.EntityFramework;


namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Console.WriteLine("-------");

            EfCarTest();

            Console.WriteLine("-------");

            EfColorTest();

            Console.WriteLine("-------");

            EfBrandTest();

            Console.WriteLine("-------");

            DtoTest();
        }

        private static void DtoTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("Araç Listesi");
            foreach (var item in carManager.GetAllDetails())
            {
                Console.WriteLine("araba adı: " + item.CarName + "  fiyatı: " + item.DailyPrice + "  rengi: " + item.ColorName + "       brand: " + item.BrandName);
            }
        }

        private static void EfBrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var item in brandManager.GetAll())
            {
                Console.WriteLine(item.BrandName);
            }
        }

        private static void EfColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var item in colorManager.GetAll())
            {
                Console.WriteLine(item.ColorName);
            }
        }

        private static void EfCarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var item in carManager.GetCarsByBrandId(3))
            {
                Console.WriteLine(item.Description);
            }
        }
    }
}