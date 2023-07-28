using AlfredHospital.DataAccess;
using AlfredHospital.DataAccess.Repository.IRepository;
using AlfredHospital.Models;
using AlfredHospital.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AlfredHospitalWeb.Controllers;
[Area("Admin")]

[Authorize(Roles = SD.Role_Admin)]
public class ReceptionistController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public ReceptionistController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Receptionist> objReceptionistList = _unitOfWork.Receptionist.GetAll();
            return View(objReceptionistList);
        }

        //Get 
        public IActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Receptionist obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Receptionist.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Receptionist Created Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Get 
        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
           
            var ReceptionistFromDbFirst = _unitOfWork.Receptionist.GetFirstOrDefault(u => u.Id == id);
           
            if (ReceptionistFromDbFirst == null)
            {
                return NotFound();
            }

            return View(ReceptionistFromDbFirst);
        }



        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Receptionist obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Receptionist.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Receptionist Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            
            var ReceptionistFromDbFirst = _unitOfWork.Receptionist.GetFirstOrDefault(u => u.Id == id);

            if (ReceptionistFromDbFirst == null)
            {
                return NotFound();
            }

            return View(ReceptionistFromDbFirst);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.Receptionist.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Receptionist.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Receptionist Deleted Successfully";
            return RedirectToAction("Index");
        }

    }




