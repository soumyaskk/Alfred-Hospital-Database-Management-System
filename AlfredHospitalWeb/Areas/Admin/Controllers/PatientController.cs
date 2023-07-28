using AlfredHospital.DataAccess;
using AlfredHospital.DataAccess.Repository.IRepository;
using AlfredHospital.Models;
using AlfredHospital.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlfredHospitalWeb.Controllers;
[Area("Admin")]
[Authorize(Roles = SD.Role_Admin)]
    public class PatientController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public PatientController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Patient> objPatientList = _unitOfWork.Patient.GetAll();
            return View(objPatientList);
        }

        //Get 
        public IActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Patient obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Patient.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Patient Created Successfully";
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
            // var patientFromDb = _db.Patients.Find(id);
            // var patientFromDbFirst = _db.Patients.FirstOrDefault(u=>u.Id==id);
            var patientFromDbFirst = _unitOfWork.Patient.GetFirstOrDefault(u => u.Id == id);
            //var patientFromDbSingle = _db.Patients.SingleOrDefault(u => u.Id == id);

            if (patientFromDbFirst == null)
            {
                return NotFound();
            }

            return View(patientFromDbFirst);
        }



        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Patient obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Patient.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Patient Updated Successfully";
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
            // var patientFromDb = _db.Patients.Find(id);
            var patientFromDbFirst = _unitOfWork.Patient.GetFirstOrDefault(u => u.Id == id);
            //var patientFromDbSingle = _db.Patients.SingleOrDefault(u => u.Id == id);

            if (patientFromDbFirst == null)
            {
                return NotFound();
            }

            return View(patientFromDbFirst);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.Patient.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Patient.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Patient Deleted Successfully";
            return RedirectToAction("Index");
        }

    }




