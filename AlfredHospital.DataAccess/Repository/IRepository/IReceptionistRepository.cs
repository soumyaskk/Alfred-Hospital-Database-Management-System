using AlfredHospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfredHospital.DataAccess.Repository.IRepository
{
    public interface IReceptionistRepository : IRepository<Receptionist>
    {
        // update method here
        void Update(Receptionist obj);
       
    }
}
