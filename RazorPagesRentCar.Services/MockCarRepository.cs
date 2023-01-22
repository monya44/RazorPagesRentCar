using RazorPagesRentCar.Models;
using System.Collections.Generic;
using System.Linq;

namespace RazorPagesRentCar.Services
{
    public class MockCarRepository : ICarRepository
    {
        private List<Car> _carList;

        public MockCarRepository()
        {
            _carList = new List<Car>()
            {
                new Car{ Id = 1, Name = "Audi", Price = 500, PhotoPath = "Audi.jpg", District = Dist.Botanica},
                new Car{ Id = 2, Name = "Lexus", Price = 100, PhotoPath = "Lexus.jpg", District = Dist.Telecentru},
                new Car{ Id = 3, Name = "BMW", Price = 700, PhotoPath = "BMW.jpg", District = Dist.Ciocana},
                new Car{ Id = 4, Name = "Opel", Price = 400, PhotoPath = "Opel.jpg", District = Dist.Botanica},
                new Car{ Id = 5, Name = "Jeep", Price = 600, PhotoPath = "Jeep.jpg", District = Dist.Centru},
                new Car{ Id = 6, Name = "Renault", Price = 450, PhotoPath = "Renault.jpg", District = Dist.Telecentru},
                new Car{ Id = 7, Name = "Porshe", Price = 990, PhotoPath = "Porshe.jpg", District = Dist.Botanica},
                new Car{ Id = 8, Name = "Dacia", Price = 290, PhotoPath = "Dacia.jpg", District = Dist.Ciocana},
                new Car{ Id = 9, Name = "KIA", Price = 650, PhotoPath = "KIA.jpg", District = Dist.Ciocana},
                new Car{ Id = 10, Name = "Toyota", Price = 340, PhotoPath = "Toyota.jpg", District = Dist.Centru}
            };
        }

        public Car Add(Car addCar)
        {
           addCar.Id = _carList.Max(x => x.Id) + 1;
           _carList.Add(addCar);
           return addCar;
        }

        public Car Delete(int id)
        {
            Car carToDelete = _carList.FirstOrDefault(x => x.Id == id);

            if(carToDelete != null)
                _carList.Remove(carToDelete);

            return carToDelete;
        }

        public IEnumerable<DistHeadCount> CarCountByDept(Dist? dept)
        {
            IEnumerable<Car> query = _carList;
            if(dept.HasValue)
                query = query.Where(x => x.District == dept.Value);

            return query.GroupBy(x => x.District)
                .Select(x => new DistHeadCount()
                {
                    District = x.Key.Value,
                    Count = x.Count()
                }).ToList();
        }

        public IEnumerable<Car> GetAllCars()
        {
            return _carList;
        }

        public Car GetCar(int id)
        {
            return _carList.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Car> Search(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return _carList;

            return _carList.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower()));
        }

        public Car Update(Car updatedCar)
        {
            Car car = _carList.FirstOrDefault(x => x.Id == updatedCar.Id);

            if (car != null)
            {
                car.Name = updatedCar.Name;
                car.Price = updatedCar.Price;
                car.District = updatedCar.District;
                car.PhotoPath = updatedCar.PhotoPath;

            }
            return car;
        }
    }
}
