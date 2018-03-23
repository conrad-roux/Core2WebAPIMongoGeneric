using Core2WebAPIMongoGeneric.Models;
using Core2WebAPIMongoGeneric.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Core2WebAPIMongoGeneric.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UserController : Controller
    {
        UserService service = new UserService();

        // GET: api/Users
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return service.Get(x => true);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            return service.GetById(x => x.Id == id);
        }

        // Create POST: api/Users
        [HttpPost]
        public bool Post([FromBody]User user)
        {
            service.Create(user);
            return true;
        }

        // update PUT: api/Users/5
        [HttpPut("{id}")]
        public bool Put(string id, [FromBody]User user)
        {
            service.Update(id, user);
            return true;
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public bool Delete(string id)
        {
            service.Delete(id);
            return true;
        }
    }
}
