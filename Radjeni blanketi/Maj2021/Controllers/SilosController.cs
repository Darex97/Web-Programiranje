using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;

namespace Template.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SilosController : ControllerBase
    {
        IspitDbContext Context { get; set; }

        public SilosController(IspitDbContext context)
        {
            Context = context;
        }
    }
}