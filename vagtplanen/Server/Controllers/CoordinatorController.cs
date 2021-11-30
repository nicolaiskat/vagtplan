using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vagtplanen.Server.Services;

namespace vagtplanen.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoordinatorController : ControllerBase
    {
        private CoordinatorService _service;
        public CoordinatorController(CoordinatorService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var list = await _service.Get();
                return Ok(list);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{un}", Name = "CoordinatorById")]
        public async Task<IActionResult> Get(string un)
        {
            try
            {
                var coor = await _service.Get(un);
                if (coor == null)
                    return NotFound();
                return Ok(coor);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create(Coordinator coor)
        {
            try
            {
                var _coor = _service.CreateCoordinator(coor);
                return CreatedAtRoute("CoordinatorById", _coor);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
    }
}
