using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesRentCar.Models;
using RazorPagesRentCar.Services;

namespace RazorPagesRentCar.Pages.Cars
{
    public class DetailsModel : PageModel
    {
        private readonly ICarRepository _carRepository;
        public DetailsModel(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public Car Cars { get; private set; }

        public IActionResult OnGet(int id)
        {
            Cars = _carRepository.GetCar(id);

            if(Cars == null)
                return RedirectToPage("/NotFound");

            return Page();
        }
    }
}
