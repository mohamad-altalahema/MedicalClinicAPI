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
    public class CommentController : ControllerBase
    {
        IRepository<Comments> CommentRepos;

        public CommentController(IRepository<Comments> repository)
        {
            CommentRepos = repository;
        }
        // GET: api/<CommentController>
        [HttpGet]
        public async Task<IActionResult> GetComments()
        {
            var data = await CommentRepos.View();
            return Ok(data);
        }

        // GET api/<CommentController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentById(int id)
        {
            try
            {
                var comment = await CommentRepos.Find(id);

                if (comment == null)
                {
                    return NotFound($"Comment with Id = {id} not found");
                }

                return Ok(comment);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data");
            }
        }


        // POST api/<CommentController>
        [HttpPost]
        public async Task<IActionResult> AddComment(Comments comment)
        {
            await CommentRepos.Add(comment);
            return Ok(comment);
        }

        // PUT api/<CommentController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment(int Id, Comments comment)
        {
            await CommentRepos.Update(Id, comment);
            return Ok(comment);
        }

        // DELETE api/<CommentController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteComment(int id)
        {
            try
            {
                var data = await CommentRepos.Find(id);

                if (data == null)
                {
                    return NotFound($"Comment with Id = {id} not found");
                }

                await CommentRepos.Delete(id);
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
