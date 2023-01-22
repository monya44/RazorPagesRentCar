using Microsoft.AspNetCore.Mvc;
using RazorPagesRentCar.Models;
using RazorPagesRentCar.Services;

namespace RazorPagesRentCar.ViewComponents
{
    public class HeadCountViewComponent : ViewComponent
    {
        private readonly ICarRepository _carRepository;

        public HeadCountViewComponent(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public IViewComponentResult Invoke(Dist? district = null)
        {
            var result = _carRepository.CarCountByDept(district);
            return View(result);
        }
    }
}
