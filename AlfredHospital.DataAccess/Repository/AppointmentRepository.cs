using AlfredHospital.DataAccess.Repository.IRepository;
using AlfredHospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfredHospital.DataAccess.Repository
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {

        private ApplicationDbContext _db;

        public AppointmentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Appointment obj)
        {
            var objFromDb = _db.Appointments.FirstOrDefault(u => u.Id == obj.Id);
            // different way when we dont want to update everything
            if (objFromDb != null)
            {
                objFromDb.AppointmentDate = obj.AppointmentDate;
                objFromDb.Reason = obj.Reason;
                objFromDb.PhysicianId = obj.PhysicianId;
                objFromDb.RoomId = obj.RoomId;


            }
            // add something here - 103
        }
    }
}
