using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace MedicalClinicFinalProject.Models.Repository
{
    public interface IRepository<TEntity>
    {

        Task<IEnumerable<TEntity>> View();

        Task<TEntity> Find(int Id);

        Task<TEntity> Add(TEntity entity);

        Task<TEntity> Update(int Id, TEntity entity);

        Task<TEntity> Delete(int Id);
    }
}
