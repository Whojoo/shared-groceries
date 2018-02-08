using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SharedGrocery.Models;
using SharedGrocery.Repositories;

namespace SharedGrocery.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IUserRepository _userRepository;

        public ValuesController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new[] {"value1", "value2"};
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
            var user = new User
            {
                Token = "token"
            };
            _userRepository.Save(user);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}