using AlfredHospital.DataAccess.Repository.IRepository;
using AlfredHospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfredHospital.DataAccess.Repository
{
    public class NurseRepository : Repository<Nurse>, INurseRepository
    {

        private ApplicationDbContext _db;

        public NurseRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Nurse obj)
        {
           _db.Nurses.Update(obj);
        }
    }
}
