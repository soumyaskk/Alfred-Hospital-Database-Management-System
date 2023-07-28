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
[Authorize(Roles = SD.Role_Admin + "," + SD.Role_Biller + "," + SD.Role_Receptionist + "," + SD.Role_Physician)]
public class AppointmentController : Controller
{

    private readonly IUnitOfWork _unitOfWork;

    public AppointmentController(IUnitOfWork unitOfWork)
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
        AppointmentVM appointmentVM = new()
        {
            Appointment = new(),
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

			ReceptionistList = _unitOfWork.Receptionist.GetAll().Select(i => new SelectListItem
			{
				Text = i.FirstName + " " + i.LastName,
				Value = i.Id.ToString()
			}),
			RoomList = _unitOfWork.Room.GetAll().Select(i => new SelectListItem
			{
				Text = i.RoomType + " " + i.Status,
				Value = i.Id.ToString()
			}),

		};

		if (id == null || id == 0)
        {
            //create appointment
            //ViewBag.PatientList = PatientList;// store some data
			//ViewData["PhysicianList"] = PhysicianList;
			return View(appointmentVM);
        }
        else
        {
            appointmentVM.Appointment = _unitOfWork.Appointment.GetFirstOrDefault(u =>u.Id == id);
            return View(appointmentVM);
            // update appointment
        }

        
    }


    //Post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult InsertUpdate(AppointmentVM obj)
    {
        if (ModelState.IsValid)
        {
            if (obj.Appointment.Id == 0)
            {
                _unitOfWork.Appointment.Add(obj.Appointment);
            }
            else
            {
                _unitOfWork.Appointment.Update(obj.Appointment);
            }
            _unitOfWork.Save();
            TempData["success"] = "Appointment Created Successfully";
            return RedirectToAction("Index");
        }
        return View(obj);
    }

# region API Calls
[HttpGet]

public IActionResult GetAll()
{
    var appointmentList = _unitOfWork.Appointment.GetAll(includeProperties:"Patient,Physician,Receptionist,Room"); 
    return Json(new {data = appointmentList});
}
	#endregion
}






