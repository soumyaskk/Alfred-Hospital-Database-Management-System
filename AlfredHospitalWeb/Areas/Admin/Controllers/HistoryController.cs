using AlfredHospital.DataAccess;
using AlfredHospital.DataAccess.Repository.IRepository;
using AlfredHospital.Models;
using AlfredHospital.Models.ViewModels;
using AlfredHospital.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AlfredHospitalWeb.Controllers;
[Area("Admin")]
[Authorize(Roles = SD.Role_Admin + "," + SD.Role_Physician + "," + SD.Role_Nurse)]
public class HistoryController : Controller
{

    private readonly IUnitOfWork _unitOfWork;

    public HistoryController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        
        return View();
    }


    //GET
    public IActionResult InsertUpdate(int? id)
    {
        HistoryVM historyVM = new()
        {
            History = new(),
            PatientList = _unitOfWork.Patient.GetAll().Select(i => new SelectListItem
            {
                Text = i.FirstName + " " + i.LastName,
                Value = i.Id.ToString()
            }),
            PhysicianList = _unitOfWork.Physician.GetAll().Select(i => new SelectListItem
            {
                Text = i.FirstName + " " + i.LastName,
                Value = i.Id.ToString()
            }),

            AppointmentList = _unitOfWork.Appointment.GetAll().Select(i => new SelectListItem
            {
                Text = i.Reason,
                Value = i.Id.ToString()
            }),


        };

		if (id == null || id == 0)
        {
           
            //ViewBag.PatientList = PatientList;// store some data
			//ViewData["PhysicianList"] = PhysicianList;
			return View(historyVM);
        }
        else
        {
            historyVM.History = _unitOfWork.History.GetFirstOrDefault(u =>u.Id == id);
            return View(historyVM);
            
        }

        
    }


    //Post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult InsertUpdate(HistoryVM obj)
    {
        if (ModelState.IsValid)
        {
            if (obj.History.Id == 0)
            {
                _unitOfWork.History.Add(obj.History);
            }
            else
            {
                _unitOfWork.History.Update(obj.History);
            }
            _unitOfWork.Save();
            TempData["success"] = "Patient History Record Created Successfully";
            return RedirectToAction("Index");
        }
        return View(obj);
    }

# region API Calls
[HttpGet]

public IActionResult GetAll()
{
    var historyList = _unitOfWork.History.GetAll(includeProperties:"Patient,Physician,Appointment"); 
    return Json(new {data = historyList});
}
	#endregion
}






