using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace MedicalClinicFinalProject.Models.Repository
{
    public class dbCommentsRepository : IRepository<Comments>
    {
        public AppDBContext db { get; }

        public dbCommentsRepository(AppDBContext _db)
        {
            db = _db;
        }
        async public Task<Comments> Add(Comments entity)
        {
            var result = await db.Comments.AddAsync(entity);
            await db.SaveChangesAsync();
            return result.Entity;
        }

        async public Task<Comments> Delete(int Id)
        {
            var result = await db.Comments.SingleOrDefaultAsync(x => x.CommentID == Id);

            if (result != null)
            {
                db.Comments.Remove(result);
                await db.SaveChangesAsync();
                return result;
            }
            return null;
        }

        async public Task<Comments> Find(int Id)
        {
            return await db.Comments.SingleOrDefaultAsync(x => x.CommentID == Id);
        }

        async public Task<Comments> Update(int Id, Comments entity)
        {
            var result = await db.Comments.SingleOrDefaultAsync(x => x.CommentID == Id);

            if (result != null)
            {
                result.PatientId= entity.PatientId;
                result.Description=entity.Description;
                result.Rate=entity.Rate;
                result.PostedDate=entity.PostedDate;
                await db.SaveChangesAsync();
                return result;
            }
            return null;
        }

        async public Task<IEnumerable<Comments>> View()
        {
            return await db.Comments.ToListAsync();
        }
    }
}
