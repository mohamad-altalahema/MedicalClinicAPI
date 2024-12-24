using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace MedicalClinicFinalProject.Models.Repository
{
    public class dbDoctorsRepository : IRepository<Doctors>
    {
        public AppDBContext db { get; }

        public dbDoctorsRepository(AppDBContext _db)
        {
            db = _db;
        }
        async public Task<Doctors> Add(Doctors entity)
        {
            var result = await db.Doctors.AddAsync(entity);
            await db.SaveChangesAsync();
            return result.Entity;
        }

        async public Task<Doctors> Delete(int Id)
        {
            var result = await db.Doctors.SingleOrDefaultAsync(x => x.DoctorID == Id);

            if (result != null)
            {
                db.Doctors.Remove(result);
                await db.SaveChangesAsync();
                return result;
            }
            return null;
        }

        async public Task<Doctors> Find(int Id)
        {
            return await db.Doctors.SingleOrDefaultAsync(x => x.DoctorID == Id);
        }

        async public Task<Doctors> Update(int Id, Doctors entity)
        {
            var result = await db.Doctors.SingleOrDefaultAsync(x => x.DoctorID == Id);

            if (result != null)
            {
                result.DoctorFirstName= entity.DoctorFirstName;
                result.DoctorFirstName = entity.DoctorLastName;
                result.Specialization=entity.Specialization;
                result.ContactNumber=entity.ContactNumber;
                result.Email= entity.Email;
                result.AvailabilitySchedule=entity.AvailabilitySchedule;
                result.ConsultationFee=entity.ConsultationFee;
                result.Education = entity.Education;
                result.Experience= entity.Experience;
                result.DateJoined=entity.DateJoined;
                result.LastUpdated= entity.LastUpdated;
                await db.SaveChangesAsync();
                return result;
            }
            return null;
        }

        async public Task<IEnumerable<Doctors>> View()
        {
            return await db.Doctors.ToListAsync();
        }
    }
}
