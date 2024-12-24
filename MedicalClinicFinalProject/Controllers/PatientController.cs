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
    public class PatientController : ControllerBase
    {
        IRepository<Patients> PatientRepos;

        public PatientController(IRepository<Patients> repository)
        {
            PatientRepos = repository;
        }

        // GET: api/<PatientController>
        [HttpGet]
        public async Task<IActionResult> GetPatients()
        {
            var data = await PatientRepos.View();
            return Ok(data);
        }


        // GET api/<PatientController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            try
            {
                var patient = await PatientRepos.Find(id);

                if (patient == null)
                {
                    return NotFound($"Patient with Id = {id} not found");
                }

                return Ok(patient);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data");
            }
        }


        // POST api/<PatientController>
        [HttpPost]
        public async Task<IActionResult> AddPatient(Patients patient)
        {
            await PatientRepos.Add(patient);
            return Ok(patient);
        }

        // PUT api/<PatientController>/5
        [HttpPut]
        public async Task<IActionResult> UpdatePatient(int Id, Patients patient)
        {
            await PatientRepos.Update(Id, patient);
            return Ok(patient);
        }


        [HttpDelete("id")]
        public async Task<ActionResult> DeletePatient(int id)
        {
            try
            {
                var data = await PatientRepos.Find(id);

                if (data == null)
                {
                    return NotFound($"Patient with Id = {id} not found");
                }

                 await PatientRepos.Delete(id);
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
