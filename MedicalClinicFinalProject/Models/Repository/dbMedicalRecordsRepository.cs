using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace MedicalClinicFinalProject.Models.Repository
{
    public class dbMedicalRecordsRepository : IRepository<MedicalRecords>
    {
        public AppDBContext db { get; }

        public dbMedicalRecordsRepository(AppDBContext _db)
        {
            db = _db;
        }
        async public Task<MedicalRecords> Add(MedicalRecords entity)
        {
            var result = await db.MedicalRecords.AddAsync(entity);
            await db.SaveChangesAsync();
            return result.Entity;
        }

        async public Task<MedicalRecords> Delete(int Id)
        {
            var result = await db.MedicalRecords.SingleOrDefaultAsync(x => x.RecordID == Id);

            if (result != null)
            {
                db.MedicalRecords.Remove(result);
                await db.SaveChangesAsync();
                return result;
            }
            return null;
        }

        async public Task<MedicalRecords> Find(int Id)
        {
           return await db.MedicalRecords.SingleOrDefaultAsync(x => x.RecordID == Id);
        }

        async public Task<MedicalRecords> Update(int Id, MedicalRecords entity)
        {
            var result = await db.MedicalRecords.SingleOrDefaultAsync(x => x.RecordID == Id);

            if (result != null)
            {
                result.PatientId= entity.PatientId;
                result.DoctorID = entity.DoctorID;
                result.VisitDate= entity.VisitDate;
                result.Diagnosis=entity.Diagnosis;
                result.Prescription=entity.Prescription;
                result.TestsRecommended=entity.TestsRecommended;
                result.Notes=entity.Notes;
                result.DateCreated=entity.DateCreated;
                result.LastUpdated=entity.LastUpdated;
                await db.SaveChangesAsync();
                return result;
            }
            return null;
        }

        async public Task<IEnumerable<MedicalRecords>> View()
        {
            return await db.MedicalRecords.ToListAsync();
        }
    }
}
