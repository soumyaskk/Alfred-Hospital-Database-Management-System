using AlfredHospital.DataAccess.Repository.IRepository;
using AlfredHospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfredHospital.DataAccess.Repository
{
    public class PhysicianRepository : Repository<Physician>, IPhysicianRepository
	{

        private ApplicationDbContext _db;

        public PhysicianRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Physician obj)
        {
           _db.Physicians.Update(obj);
        }
    }
}
