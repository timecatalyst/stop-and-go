using System.IO;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace StopAndGo.Api.Controllers
{
    public class SinglePageApplicationController : Controller
    {
        private readonly IHostingEnvironment _env;

        public SinglePageApplicationController(IHostingEnvironment env) => _env = env;

        [HttpGet]
        public IActionResult Index()
        {
            var indexHtmlPath = Path.Combine(_env.WebRootPath, "react", "index.html");
            return Content(System.IO.File.ReadAllText(indexHtmlPath), "text/html", Encoding.UTF8);
        }
    }
}
