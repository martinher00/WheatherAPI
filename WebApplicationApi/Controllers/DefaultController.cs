﻿using BusLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplicationApi.Controllers
{
    public class DefaultController : ApiController
    {
        // GET: api/Default
        public IEnumerable<Weather> Get()
        {
            Weather weather = new Weather();
            return weather.GetAllWeatherValues();
        }

        // GET: api/Default/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Default
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Default/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Default/5
        public void Delete(int id)
        {
        }
    }
}
