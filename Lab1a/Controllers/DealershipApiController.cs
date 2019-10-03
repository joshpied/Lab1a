using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab1a.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab1a.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealershipApiController : ControllerBase
    {
        // GET: api/DealershipApi -> https://localhost:44319/api/DealershipApi
        [HttpGet]
        public IEnumerable<Dealership> Get()
        {
            var dealerships = new DealershipMgr().Get();
            return dealerships;
        }

        // GET: api/DealershipApi/5
        [HttpGet("{id}", Name = "Get")]
        public Dealership Get(int id)
        {
            var dealership = new DealershipMgr().Get(id);
            return dealership;
        }

        // POST: api/DealershipApi
        [HttpPost]
        public Dealership Post([FromBody] Dealership value)
        {
            var dealership = new DealershipMgr().Post(value);
            return dealership;
        }

        // PUT: api/DealershipApi/5
        [HttpPut("{id}")]
        public Dealership Put(int id, [FromBody] Dealership value)
        {
            var dealership = new DealershipMgr().Put(id, value);
            return dealership;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            new DealershipMgr().Delete(id);
        }
    }
}
