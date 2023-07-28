using AlfredHospital.DataAccess.Repository.IRepository;
using AlfredHospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfredHospital.DataAccess.Repository
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {

        private ApplicationDbContext _db;

        public RoomRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Room obj)
        {
           _db.Rooms.Update(obj);
            // can update only some elements like Appointment
        }
    }
}
