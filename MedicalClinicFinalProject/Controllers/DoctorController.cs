using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using MedicalClinicFinalProject.Models;
using MedicalClinicFinalProject.Models.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalClinicFinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        IRepository<Doctors> DoctorRepos;

        public DoctorController(IRepository<Doctors> repository)
        {
            DoctorRepos = repository;
        }




        // GET: api/<DoctorController>
        [HttpGet]
        public async Task<IActionResult> GetDoctors()
        {

            var data = await DoctorRepos.View();
            return Ok(data);
        }

        
        // GET api/<DoctorController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctorById(int id)
        {
            try
            {
                var doctor = await DoctorRepos.Find(id);

                if (doctor == null)
                {
                    return NotFound($"Doctor with Id = {id} not found");
                }

                return Ok(doctor);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data");
            }
        }


        // POST api/<DoctorController>
        [HttpPost]
        public async Task<IActionResult> AddDoctor(Doctors doctor)
        {
            await DoctorRepos.Add(doctor);
            return Ok(doctor);
        }

          // PUT api/<DoctorController>/5
        [HttpPut]
        public async Task<IActionResult> UpdateDoctor(int Id, Doctors doctor)
        {
            await DoctorRepos.Update(Id, doctor);
            return Ok(doctor);
        }


        // DELETE api/<DoctorController>/5
        [HttpDelete("{id}")]
       public async Task<ActionResult> DeleteDoctor(int id)
        {
            try
            {
                var data = await DoctorRepos.Find(id);

                if (data == null)
                {
                    return NotFound($"Doctor with Id = {id} not found");
                }

                 await DoctorRepos.Delete(id);
                return Ok(data);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}
