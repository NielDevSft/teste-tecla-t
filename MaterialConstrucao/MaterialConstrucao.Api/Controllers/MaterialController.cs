using MaterialConstrucao.Api.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace MaterialConstrucao.Api.Controllers
{
    [Route("material")]
    public class MaterialController : Controller
    {
        [HttpGet]
        [Route("lista-filtro")]
        [EnableCors]
        public IActionResult SelectByFilter(string name, string ordPrice, bool unicByMarca, int numItems)
        {
            var service = new MaterialService();
            return Ok(service.SelectByFilter(name, ordPrice, unicByMarca, numItems));
        }
    }
}