using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vagtplanen.Server.Services;

namespace vagtplanen.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MethodController : ControllerBase
    {
        private MethodService _service;
        public MethodController(MethodService service)
        {
            _service = service;
        }


        [HttpGet("{un}/{pw}")]
        public async Task<ActionResult> Get(string un, string pw)
        {
            try
            {
                var result = await _service.CheckLogin(un, pw);
                return Ok(result);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
    }
}
