using AlfredHospital.DataAccess.Repository.IRepository;
using AlfredHospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfredHospital.DataAccess.Repository
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {

        private ApplicationDbContext _db;

        public PatientRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Patient obj)
        {
           _db.Patients.Update(obj);
        }
    }
}
