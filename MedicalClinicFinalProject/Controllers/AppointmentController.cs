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
    public class AppointmentController : ControllerBase
    {
        IRepository<Appointments> AppointmentRepos;

        public AppointmentController(IRepository<Appointments> repository)
        {
            AppointmentRepos = repository;
        }

        // GET: api/<AppointmentController>
        [HttpGet]
        public async Task<IActionResult> GetAppointments()
        {
            var data = await AppointmentRepos.View();
            return Ok(data);
        }

        // GET api/<AppointmentController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointmentById(int id)
        {
            try
            {
                var appointment = await AppointmentRepos.Find(id);

                if (appointment == null)
                {
                    return NotFound($"Appointment with Id = {id} not found");
                }

                return Ok(appointment);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data");
            }
        }


        // POST api/<AppointmentController>
        [HttpPost]
        public async Task<IActionResult> AddAppointment(Appointments appointment)
        {
            await AppointmentRepos.Add(appointment);
            return Ok(appointment);
        }

        // PUT api/<AppointmentController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAppointment(int Id, Appointments appointment)
        {
            await AppointmentRepos.Update(Id, appointment);
            return Ok(appointment);
        }

        // DELETE api/<AppointmentController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAppointment(int id)
        {
            try
            {
                var data = await AppointmentRepos.Find(id);

                if (data == null)
                {
                    return NotFound($"Appointment with Id = {id} not found");
                }

                 await AppointmentRepos.Delete(id);
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
