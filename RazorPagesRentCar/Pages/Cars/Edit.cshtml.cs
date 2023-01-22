using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesRentCar.Models;
using RazorPagesRentCar.Services;
using System;
using System.IO;

namespace RazorPagesRentCar.Pages.Cars
{
    public class EditModel : PageModel
    {
        private readonly ICarRepository _carRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EditModel(ICarRepository carRepository, IWebHostEnvironment webHostEnvironment)
        {
            _carRepository = carRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        [BindProperty]
        public Car Cars { get; set; }

        [BindProperty]
        public IFormFile Photo { get; set; }

        [BindProperty]
        public bool Notify { get; set; }
        public string Message { get; set; }

        public IActionResult OnGet(int? id)
        {
            if(id.HasValue)
                Cars = _carRepository.GetCar(id.Value);
            else
                Cars = new Car();

            if (Cars == null)
                return RedirectToPage("/NotFound");

            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {

                if (Photo != null)
                {
                    if (Cars.PhotoPath != null)
                    {
                        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", Cars.PhotoPath);
                        System.IO.File.Delete(filePath);
                    }

                    Cars.PhotoPath = ProcessUploadedFile();
                }
                if (Cars.Id > 1)
                {

                    Cars = _carRepository.Update(Cars);
                    TempData["SuccessMessage"] = $"Update {Cars.Name} succesful!";
                }
                else
                {
                    Cars = _carRepository.Add(Cars);
                    TempData["SuccessMessage"] = $"Adding {Cars.Name} succesful!";
                }
                return RedirectToPage("Cars");

            }
            return Page();
            
        }

        public void OnPostUpdateNotificationPreference(int id)
        {
            if (Notify)
                Message = "Thank you for turning on notifications";
            else
                Message = "You have turned off email notifications";

            Cars = _carRepository.GetCar(id);
        }

        private string ProcessUploadedFile()
        {
            string uniqueFileName = null;

            if(Photo != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath,"images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fs = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fs);
                }
            }
            return uniqueFileName;
        }


    }
}
