using AlfredHospital.DataAccess.Repository.IRepository;
using AlfredHospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfredHospital.DataAccess.Repository
{
    public class BillingRepository : Repository<Billing>, IBillingRepository
    {

        private ApplicationDbContext _db;

        public BillingRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Billing obj)
        {
           _db.Billings.Update(obj);
        }
    }
}
