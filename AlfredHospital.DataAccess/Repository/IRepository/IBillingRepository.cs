using AlfredHospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfredHospital.DataAccess.Repository.IRepository
{
    public interface IBillingRepository : IRepository<Billing>
    {
        // update method here
        void Update(Billing obj);
       
    }
}
