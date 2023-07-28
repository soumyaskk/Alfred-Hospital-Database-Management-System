using AlfredHospital.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfredHospital.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db) 
        { 
            _db = db;
            Patient = new PatientRepository(_db);
            Physician = new PhysicianRepository(_db);
            Appointment = new AppointmentRepository(_db);
            Nurse = new NurseRepository(_db);
            Receptionist = new ReceptionistRepository(_db);
            Billing = new BillingRepository(_db);
            Room = new RoomRepository(_db);
            History = new HistoryRepository(_db);
        }
        public IPatientRepository Patient{get; private set;}

		public IPhysicianRepository Physician { get; private set; }

        public IAppointmentRepository Appointment { get; private set; }

        public INurseRepository Nurse { get; private set; }

        public IReceptionistRepository Receptionist { get; private set; }

        public IBillingRepository Billing { get; private set; }

        public IRoomRepository Room { get; private set; }

        public IHistoryRepository History { get; private set; }


        public void Save()
        {
           _db.SaveChanges();
        }
    }
}
