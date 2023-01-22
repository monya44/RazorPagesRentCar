using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesRentCar.Models;
using RazorPagesRentCar.Services;
using System.Collections.Generic;

namespace RazorPagesRentCar.Pages.Cars
{
    public class CarsModel : PageModel
    {
        private readonly ICarRepository _db;
        public CarsModel(ICarRepository db)
        {
            _db = db;
        }

        public IEnumerable<Car> Car { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public void OnGet()
        {
            Car = _db.Search(SearchTerm);
        }
    }
}
