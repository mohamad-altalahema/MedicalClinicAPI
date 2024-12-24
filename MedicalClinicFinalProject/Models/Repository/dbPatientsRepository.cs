using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace MedicalClinicFinalProject.Models.Repository
{
    public class dbPatientsRepository : IRepository<Patients>
    {
        public AppDBContext db { get; }

        public dbPatientsRepository(AppDBContext _db)
        {
            db = _db;
        }
        async public Task<Patients> Add(Patients entity)
        {
            var result = await db.Patients.AddAsync(entity);
            await db.SaveChangesAsync();
            return result.Entity;
        }

        async public Task<Patients> Delete(int Id)
        {
            var result = await db.Patients.SingleOrDefaultAsync(x => x.PatientId == Id);

            if (result != null)
            {
                db.Patients.Remove(result);
                await db.SaveChangesAsync();
                return result;
            }
            return null;
        }

        async public Task<Patients> Find(int Id)
        {
            return await db.Patients.SingleOrDefaultAsync(x => x.PatientId == Id);
        }

        async public Task<Patients> Update(int Id, Patients entity)
        {
            var result = await db.Patients.SingleOrDefaultAsync(x => x.PatientId == Id);

            if (result != null)
            {
                result.PatientFirstName=entity.PatientFirstName;
                result.PatientLastName=entity.PatientLastName;
                result.DateOfBirth=entity.DateOfBirth;
                result.Gender=entity.Gender;
                result.ContactNumber=entity.ContactNumber;
                result.Email=entity.Email;
                result.Address=entity.Address;
                result.EmergencyContact=entity.EmergencyContact;
                result.InsuranceProvider=entity.InsuranceProvider;
                result.InsurancePolicyNumber=entity.InsurancePolicyNumber;
                result.DateCreated=entity.DateCreated;
                result.LastUpdated= entity.LastUpdated;
                await db.SaveChangesAsync();
                return result;
            }
            return null;
        }

        async public Task<IEnumerable<Patients>> View()
        {
            return await db.Patients.ToListAsync();
        }
    }
}
