using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorServer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroPonto2Controller : ControllerBase
    {
        [HttpGet]
        [Route("PdfReport")]
        public IActionResult PDFReport()
        {
            return null;
        }



    }
}
