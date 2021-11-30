using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vagtplanen.Server.Services;

namespace vagtplanen.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolunteerController : ControllerBase
    {
        private VolunteerService _service;
        public VolunteerController(VolunteerService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var list = _service.Get();
                return Ok(list);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{un}", Name = "VolunteerById")]
        public IActionResult Get(string un)
        {
            try
            {
                var coor = _service.Get(un);
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
        public IActionResult Create(Volunteer vol)
        {
            try
            {
                var _obj = _service.Create(vol);
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

        [HttpPut]
        public IActionResult Update(Volunteer vol)
        {
            try
            {
                var coor = _service.Update(vol);
                return Ok(coor);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
    }
}
