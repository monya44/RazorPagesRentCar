using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesRentCar.Models;
using RazorPagesRentCar.Services;

namespace RazorPagesRentCar.Pages.Cars
{
    public class DeleteModel : PageModel
    {
        private readonly ICarRepository _carRepository;
        public DeleteModel(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [BindProperty]
        public Car Cars { get; set; }
        public ICarRepository CarRepository { get; }

        public IActionResult OnGet(int id)
        {
            Cars = _carRepository.GetCar(id);

            if (Cars == null)
                return RedirectToPage("/NotFound");

            return Page();
        }
        public IActionResult OnPost()
        {
            Car deletedCar = _carRepository.Delete(Cars.Id);

            if (deletedCar == null)
                return RedirectToPage("/NotFound");

            return RedirectToPage("Cars");
        }
    }
}
