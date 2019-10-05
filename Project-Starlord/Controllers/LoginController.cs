﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project_Starlord.Controllers
{
    [Route("api/[controller]")]
public class LoginController : Controller
{
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
    public string Get(int id)
    {
        return $"value + {id}";
    }

    [HttpGet("{username}")]
    public bool Get(string username)
    {
        return username.ToUpperInvariant() == "ADMIN";
    }

    // POST api/<controller>
    [HttpPost]
    public bool Post([FromBody]string username)
    {
        return username.ToUpperInvariant() == "ADMIN";
    }

    // PUT api/<controller>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE api/<controller>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
}