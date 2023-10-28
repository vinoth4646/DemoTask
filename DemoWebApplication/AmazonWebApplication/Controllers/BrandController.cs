using AmazonWebApplication.Data;
using AmazonWebApplication.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AmazonWebApplication.Controllers
{
    public class BrandController : Controller
    {

        private readonly AppDBContext _dbContext;

        // to handle the file upload
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BrandController(AppDBContext dBContext, IWebHostEnvironment webHostEnvironment)
        {
            _dbContext = dBContext;
            _webHostEnvironment = webHostEnvironment;

        }

        [HttpGet]
        public IActionResult Index()
        {
            // get the list of eleements from the brand which is in the db
            List<Brand> brands = _dbContext.Brand.ToList();

            return View(brands);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Brand brand)
        {


            string path = _webHostEnvironment.WebRootPath;

            if (ModelState.IsValid)
            {
                _dbContext.Brand.Add(brand);
                _dbContext.SaveChanges();
                TempData["success"] = "Record created successfully";
                // redirect to the page to the index
                return RedirectToAction(nameof(Index));

            }
            return View();
        }

        [HttpGet]
        public IActionResult Details(Guid id)
        {
            Brand brand = _dbContext.Brand.FirstOrDefault(x => x.EmpId == id);
            return View(brand);
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {

            Brand brand = _dbContext.Brand.FirstOrDefault(x => x.EmpId == id);
            return View(brand);
        }

        [HttpPost]
        public IActionResult Edit(Brand brand)
        {

            string path = _webHostEnvironment.WebRootPath;

            if (ModelState.IsValid)
            {
                var objName = _dbContext.Brand.AsNoTracking().FirstOrDefault(x => x.EmpId == brand.EmpId);
                objName.EmpName = brand.EmpName;
                objName.Gender = brand.Gender;
                objName.Age = brand.Age;
                

                _dbContext.Brand.Update(objName);
                _dbContext.SaveChanges();
                TempData["warning"] = "Record updated successfully";
                // redirect to the page to the index
                return RedirectToAction(nameof(Index));

            }
            return View();

        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {

            Brand brand = _dbContext.Brand.FirstOrDefault(x => x.EmpId == id);
            return View(brand);
        }

        [HttpPost]
        public IActionResult Delete(Brand brand)
        {
            string path = _webHostEnvironment.WebRootPath;

            if (ModelState.IsValid)
            {
                var objName = _dbContext.Brand.AsNoTracking().FirstOrDefault(x => x.EmpId == brand.EmpId);
                objName.EmpName = brand.EmpName;
                objName.Gender = brand.Gender;
                objName.Age = brand.Age;


                _dbContext.Brand.Remove(objName);
                _dbContext.SaveChanges();
                TempData["warning"] = "Record updated successfully";
                // redirect to the page to the index
                return RedirectToAction(nameof(Index));

            }

            return View();
        }
    }
}
          


