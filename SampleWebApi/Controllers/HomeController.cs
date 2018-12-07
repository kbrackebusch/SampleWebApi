using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SampleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public string Index()
        {
            return @"<body>Code written to demonstrate caching in a web api Note use of singleton via dependency injection.  This way  a class is not 'hard coded' as a singleton.<br>
http://localhost:60289/api/LinkedList/merge?lista=1
http://localhost:60289/api/LinkedList/merge?lista=1 2 3&listb=2 3 4
</body>
";
        }
    }
}