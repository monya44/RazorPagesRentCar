using RazorPagesRentCar.Models;
using System.Collections.Generic;

namespace RazorPagesRentCar.Services
{
    public interface ICarRepository
    {
        IEnumerable<Car> Search(string SearchTerm);
        IEnumerable<Car> GetAllCars();
        Car GetCar(int id);
        Car Update(Car updatedCar); 
        Car Add(Car addCar);
        Car Delete(int id);
        IEnumerable<DistHeadCount> CarCountByDept(Dist? dist);
    }
}
