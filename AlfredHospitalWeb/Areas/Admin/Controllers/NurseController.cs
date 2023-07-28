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

public class NurseController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public NurseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Nurse> objNurseList = _unitOfWork.Nurse.GetAll();
            return View(objNurseList);
        }

        //Get 
        public IActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Nurse obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Nurse.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Nurse Created Successfully";
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
           
            var NurseFromDbFirst = _unitOfWork.Nurse.GetFirstOrDefault(u => u.Id == id);

            if (NurseFromDbFirst == null)
            {
                return NotFound();
            }

            return View(NurseFromDbFirst);
        }



        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Nurse obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Nurse.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Nurse Updated Successfully";
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
           
            var NurseFromDbFirst = _unitOfWork.Nurse.GetFirstOrDefault(u => u.Id == id);
        

            if (NurseFromDbFirst == null)
            {
                return NotFound();
            }

            return View(NurseFromDbFirst);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.Nurse.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Nurse.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Nurse Deleted Successfully";
            return RedirectToAction("Index");
        }

    }




