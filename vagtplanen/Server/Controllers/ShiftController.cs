using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vagtplanen.Server.Services;

namespace vagtplanen.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftController : ControllerBase
    {
        private ShiftService _service;
        public ShiftController(ShiftService service)
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

        [HttpGet("{id}", Name = "ShiftById")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var coor = await _service.Get(id);
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
        public IActionResult Create(Shift shift)
        {
            try
            {
                var _obj = _service.Create(shift);
                return CreatedAtRoute("CouponById", _obj);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
    }
}
