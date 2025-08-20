using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPosConnect.Lib;
using XPosConnect.Lib.Dto.Communicate;

namespace XPosConnect.Controllers
{
    [Route("home")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        
        public HomeController()
        {
            
        }

        [HttpGet("")]
        public ContentResult Home()
        {
            string someContent = "Hello. This is XPOS service.";

            return new ContentResult
            {
                Content = someContent,
                ContentType = "text/html"
            };
        }
    }
}
