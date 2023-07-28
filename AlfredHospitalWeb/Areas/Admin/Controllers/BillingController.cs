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
[Authorize(Roles = SD.Role_Admin + "," + SD.Role_Biller)]

public class BillingController : Controller
{

    private readonly IUnitOfWork _unitOfWork;

    public BillingController(IUnitOfWork unitOfWork)
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
		BillingVM billingVM = new()
        {
			Billing = new(),
            PatientList = _unitOfWork.Patient.GetAll().Select(i => new SelectListItem
            {
                Text = i.FirstName + " " + i.LastName,
                Value = i.Id.ToString()
            }),

		};

		if (id == null || id == 0)
        {
			//create Billing
			//ViewBag.PatientList = PatientList;// store some data
			//ViewData["PhysicianList"] = PhysicianList;
			return View(billingVM);
        }
        else
        {
			// update Billing
		}

		return View(billingVM);
    }


    //Post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult InsertUpdate(BillingVM obj)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.Billing.Add(obj.Billing);
            _unitOfWork.Save();
            TempData["success"] = "Billing Record Created Successfully";
            return RedirectToAction("Index");
        }
        return View(obj);
    }

    #region API Calls
    [HttpGet]

    public IActionResult GetAll()
    {
        var billingList = _unitOfWork.Billing.GetAll(includeProperties: "Patient"); 
        return Json(new { data = billingList });
    }
    #endregion
}







