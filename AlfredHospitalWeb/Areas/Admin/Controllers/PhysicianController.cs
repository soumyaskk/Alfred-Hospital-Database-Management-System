using AlfredHospital.DataAccess;
using AlfredHospital.DataAccess.Repository.IRepository;
using AlfredHospital.Models;
using AlfredHospital.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlfredHospitalWeb.Controllers;
[Area("Admin")]
[Authorize(Roles = SD.Role_Admin)]
public class PhysicianController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public PhysicianController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Physician> objPhysicianList = _unitOfWork.Physician.GetAll();
            return View(objPhysicianList);
        }

        //Get 
        public IActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Physician obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Physician.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Physician Created Successfully";
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
            
            var PhysicianFromDbFirst = _unitOfWork.Physician.GetFirstOrDefault(u => u.Id == id);
           

            if (PhysicianFromDbFirst == null)
            {
                return NotFound();
            }

            return View(PhysicianFromDbFirst);
        }



        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Physician obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Physician.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Physician Updated Successfully";
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
           
            var PhysicianFromDbFirst = _unitOfWork.Physician.GetFirstOrDefault(u => u.Id == id);
            

            if (PhysicianFromDbFirst == null)
            {
                return NotFound();
            }

            return View(PhysicianFromDbFirst);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.Physician.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Physician.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Physician Deleted Successfully";
            return RedirectToAction("Index");
        }

    }




