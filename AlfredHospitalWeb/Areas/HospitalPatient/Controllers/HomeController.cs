using AlfredHospital.DataAccess.Repository.IRepository;
using AlfredHospital.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AlfredHospitalWeb.Controllers;
[Area("HospitalPatient")]
public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
       // private readonly IUnitOfWork _unitOfWork;

    public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            //_unitOfWork = unitOfWork;   
        }

        public IActionResult Index()
        {
       // IEnumerable<Physician> physicianList = _unitOfWork.Physician.GetAll(includeProperties: "Appointment");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
