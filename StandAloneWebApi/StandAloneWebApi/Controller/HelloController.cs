using StandAloneWebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StandAloneWebApi.Controller
{
    public class HelloController : ApiController
    {
        public string Get()
        {
            return "Hello World";
        }

        public Student Post(Student student)
        {
           
            return student;
        }
    }
}
