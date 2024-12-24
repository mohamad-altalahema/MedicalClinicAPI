using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace MedicalClinicFinalProject.Models.Repository
{
    public class dbBillingRepository : IRepository<Billing>
    {
        public AppDBContext db { get; }

        public dbBillingRepository(AppDBContext _db)
        {
            db = _db;
        }
        async public Task<Billing> Add(Billing entity)
        {
            var result = await db.Billing.AddAsync(entity);
            await db.SaveChangesAsync();
            return result.Entity;
        }

        async public Task<Billing> Delete(int Id)
        {
            var result = await db.Billing.SingleOrDefaultAsync(x => x.BillID == Id);

            if (result != null)
            {
                db.Billing.Remove(result);
                await db.SaveChangesAsync();
                return result;
            }
            return null;
        }

        async public Task<Billing> Find(int Id)
        {
           return await db.Billing.SingleOrDefaultAsync(x => x.BillID == Id);
        }

        async public Task<Billing> Update(int Id, Billing entity)
        {
            var result = await db.Billing.SingleOrDefaultAsync(x => x.BillID == Id);

            if (result != null)
            {
                result.AppointmentID=entity.AppointmentID;
                result.PatientId= entity.PatientId;
                result.TotalAmount=entity.TotalAmount;
                result.PaymentStatus=entity.PaymentStatus;
                result.PaymentMethod=entity.PaymentMethod;
                result.DateCreated=entity.DateCreated;
                result.LastUpdated=entity.LastUpdated;
                await db.SaveChangesAsync();
                return result;
            }
            return null;
        }

        async public Task<IEnumerable<Billing>> View()
        {
            return await db.Billing.ToListAsync();
        }
    }
}
