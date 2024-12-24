using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace MedicalClinicFinalProject.Models.Repository
{
    public class dbAppointmentsRepository : IRepository<Appointments>
    {
        public AppDBContext db { get; }

        public dbAppointmentsRepository(AppDBContext _db)
        {
            db = _db;
        }

        async public Task<Appointments> Add(Appointments entity)
        {
            var result = await db.Appointments.AddAsync(entity);
            await db.SaveChangesAsync();
            return result.Entity;
        }

        async public Task<Appointments> Delete(int Id)
        {
            var result = await db.Appointments.SingleOrDefaultAsync(x => x.AppointmentID == Id);

            if (result != null)
            {
                db.Appointments.Remove(result);
                await db.SaveChangesAsync();
                return result;
            }
            return null;
        }

        async public Task<Appointments> Find(int Id)
        {
            return await db.Appointments.SingleOrDefaultAsync(x => x.AppointmentID == Id);
        }

        async public Task<Appointments> Update(int Id, Appointments entity)
        {
            var result = await db.Appointments.SingleOrDefaultAsync(x => x.AppointmentID == Id);

            if (result != null)
            {
                result.PatientId= entity.PatientId;
                result.DoctorID = entity.DoctorID;
                result.AppointmentDate= entity.AppointmentDate;
                result.AppointmentTime=entity.AppointmentTime;
                result.Status=entity.Status;
                result.ReasonForVisit=entity.ReasonForVisit;
                result.DateCreated=entity.DateCreated;
                result.LastUpdated=entity.LastUpdated;
                await db.SaveChangesAsync();
                return result;
            }
            return null;
        }

        async public Task<IEnumerable<Appointments>> View()
        {
            return await db.Appointments.ToListAsync();
        }
    }
}
