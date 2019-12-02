using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDiary.Models;

namespace MyDiary.API
{
    [Route("api/Contents")]
    [ApiController]
    public class APIController : Controller
    {
        private readonly MyDiaryContext _context;

        public APIController(MyDiaryContext context)
        {
            _context = context;
        }


        // GET: api/API
        [HttpGet]
        public IActionResult Get()
        {
            var list = _context.Content.ToList();
            return Json(list);
        }

        // GET: api/API/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var list = _context.Content.Where(x => x.ContentId == id).SingleOrDefault();
            return Json(list);
        }

        // POST: api/API
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/API/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
