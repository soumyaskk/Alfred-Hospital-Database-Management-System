using AlfredHospital.DataAccess;
using AlfredHospital.DataAccess.Repository.IRepository;
using AlfredHospital.Models;
using AlfredHospital.Models.ViewModels;
using AlfredHospital.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace AlfredHospitalWeb.Controllers;
[Area("Admin")]

[Authorize(Roles = SD.Role_Admin + "," + SD.Role_Receptionist + "," + SD.Role_Nurse)]
public class RoomController : Controller
{

    private readonly IUnitOfWork _unitOfWork;

    public RoomController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        IEnumerable<Room> objRoomList = _unitOfWork.Room.GetAll();
        return View(objRoomList);
    }


    //GET
    public IActionResult InsertUpdate(int? id)
    {
        RoomVM roomVM = new()
        {
			Room = new(),
            NurseList = _unitOfWork.Nurse.GetAll().Select(i => new SelectListItem
            {
                Text = i.FirstName + " " + i.LastName,
                Value = i.Id.ToString()
            }),
 

		};

		if (id == null || id == 0)
        {
			//create Room
			//ViewBag.PatientList = PatientList;// store some data
			//ViewData["PhysicianList"] = PhysicianList;
			return View(roomVM);
        }
        else
        {
			// update Room
		}

		return View(roomVM);
    }


    //Post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult InsertUpdate(RoomVM obj)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.Room.Add(obj.Room);
            _unitOfWork.Save();
            TempData["success"] = "Room Created Successfully";
            return RedirectToAction("Index");
        }
        return View(obj);
    }

    #region API Calls
    [HttpGet]

    public IActionResult GetAll()
    {
        var roomList = _unitOfWork.Room.GetAll(includeProperties: "Nurse");
        return Json(new { data = roomList });
    }
    #endregion
}






