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
    public class BillingController : ControllerBase
    {
        IRepository<Billing> BillRepos;

        public BillingController(IRepository<Billing> repository)
        {
            BillRepos = repository;
        }

        // GET: api/<BillingController>
        [HttpGet]
        public async Task<IActionResult> GetBills()
        {
            var data = await BillRepos.View();
            return Ok(data);
        }


        // GET api/<BillingController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBillingById(int id)
        {
            try
            {
                var billing = await BillRepos.Find(id);

                if (billing == null)
                {
                    return NotFound($"Billing with Id = {id} not found");
                }

                return Ok(billing);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data");
            }
        }

        // POST api/<BillingController>
        [HttpPost]
        public async Task<IActionResult> AddBills(Billing bill)
        {
            await BillRepos.Add(bill);
            return Ok(bill);
        }

        // PUT api/<BillingController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBiils(int Id, Billing billing)
        {
            await BillRepos.Update(Id, billing);
            return Ok(billing);
        }

        // DELETE api/<BillingController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBills(int id)
        {
            try
            {
                var data = await BillRepos.Find(id);

                if (data == null)
                {
                    return NotFound($"Bill with Id = {id} not found");
                }

                 await BillRepos.Delete(id);
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
