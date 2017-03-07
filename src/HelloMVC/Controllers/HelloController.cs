using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloMVC.Controllers
{
    public class HelloController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            string html = @"<form method=""post"">
                <input type=""text"" name=""name"" />
                <select name = ""greeting"">
                <option value = ""Hello"" selected> English </option>
                <option value = ""Bonjour""> French </option>
                <option value = ""Hola""> Spanish </option>
                <option value = ""Zdravo""> Bosnian </option>
                <option value = ""Kaixo""> Basque </option>
                </select>
                <input type=""submit"" value=""Greet me!"" />
                </form>";

            return Content(html, "text/html");
        }
        // /Hello
        [Route("/Hello")]
        [HttpPost]
        public IActionResult Display(string greeting, string name = "World")
        {
            return Content(string.Format("<h1>{0}, {1}</h1>", greeting, name), "text/html");
        }

        // Handle request to /Hello/NAME (URL segment)
        [Route("/Hello/{name}")]
        public IActionResult Index2(string name)
        {
            return Content(string.Format("<h1>Hello {0}</h1>", name), "text/html");
        }

        public IActionResult Goodbye()
        {
            return Content("Goodbye");
        }

        // /Monkey redirect which will totally ignore the string below, and instead call up 
        // the Goodbye function. Pefectly stupid, but it shows how to redirect. 
        [Route("/Monkey")]
        [HttpGet]
        public IActionResult Monkey(string name = "World")
        {
            string html = @"form method='post'>
                <input type='text' name='name' />
                <select name = 'select' >
                <input type='submit' value='Greet me!' />
                </form>";

            return Redirect("/Hello/Goodbye");
        }
    }
}
