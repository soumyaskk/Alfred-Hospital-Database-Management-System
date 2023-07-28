using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfredHospital.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IPatientRepository Patient {  get; }
		IPhysicianRepository Physician { get; }
        IAppointmentRepository Appointment { get; }
        INurseRepository Nurse { get; }
        IReceptionistRepository Receptionist { get; }
        IBillingRepository Billing { get; }
        IRoomRepository Room { get; }
        IHistoryRepository History { get; }

      

        void Save();
    }
}
