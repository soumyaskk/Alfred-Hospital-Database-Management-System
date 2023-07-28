using AlfredHospital.DataAccess.Repository.IRepository;
using AlfredHospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfredHospital.DataAccess.Repository
{
    public class ReceptionistRepository : Repository<Receptionist>, IReceptionistRepository
    {

        private ApplicationDbContext _db;

        public ReceptionistRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Receptionist obj)
        {
           _db.Receptionists.Update(obj);
        }
    }
}
