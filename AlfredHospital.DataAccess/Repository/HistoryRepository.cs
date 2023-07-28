using AlfredHospital.DataAccess.Repository.IRepository;
using AlfredHospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfredHospital.DataAccess.Repository
{
    public class HistoryRepository : Repository<History>, IHistoryRepository
    {

        private ApplicationDbContext _db;

        public HistoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(History obj)
        {
            var objFromDb = _db.Historys.FirstOrDefault(u => u.Id == obj.Id);
            // different way when we dont want to update everything
            if (objFromDb != null)
            {
              
                objFromDb.Treatment = obj.Treatment;
                objFromDb.PhysicianId = obj.PhysicianId;


            }
            // add something here - 103
        }
    }
}
