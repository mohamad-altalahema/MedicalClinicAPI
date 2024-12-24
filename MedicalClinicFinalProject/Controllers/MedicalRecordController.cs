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
    public class MedicalRecordController : ControllerBase
    {
        IRepository<MedicalRecords> MedicalRepos;

        public MedicalRecordController(IRepository<MedicalRecords> repository)
        {
            MedicalRepos = repository;
        }

        // GET: api/<MedicalRecordController>
        [HttpGet]
        public async Task<IActionResult> GetRecords()
        {
            var data = await MedicalRepos.View();
            return Ok(data);
        }



        // GET api/<MedicalRecordController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecordById(int id)
        {
            try
            {
                var record = await MedicalRepos.Find(id);

                if (record == null)
                {
                    return NotFound($"Record with Id = {id} not found");
                }

                return Ok(record);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data");
            }
        }

        // POST api/<MedicalRecordController>
        [HttpPost]
        public async Task<IActionResult> AddRecord(MedicalRecords record)
        {
            await MedicalRepos.Add(record);
            return Ok(record);
        }

        // PUT api/<MedicalRecordController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRecord(int Id, MedicalRecords record)
        {
            await MedicalRepos.Update(Id, record);
            return Ok(record);
        }

        // DELETE api/<MedicalRecordController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRecord(int id)
        {
            try
            {
                var data = await MedicalRepos.Find(id);

                if (data == null)
                {
                    return NotFound($"MedicalRecord with Id = {id} not found");
                }

                 await MedicalRepos.Delete(id);
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
